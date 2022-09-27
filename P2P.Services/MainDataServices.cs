using AutoMapper;
using Entities.Context;
using Entities.P2P;
using Entities.P2P.MainData;
using Entities.P2P.MainData.Settings;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Noding;
using P2P.Base.Services;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.DTO.Output.EndPointODTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P2P.Services
{
    public class MainDataServices : BaseService
    {
        public MainDataServices(MainContext context, IMapper mapper) : base(context, mapper)
        {
        }

        #region GlobalFunctions

        private async Task<List<ReviewContentDropdownODTO>> ListOfReviews()
        {
            return _context.Review.Select(r => new ReviewContentDropdownODTO
            {
                Value = r.ReviewId,
                Label = r.Name,
                Rating = r.RatingCalculated
            }).OrderByDescending(e => e.Rating).ToList();
        }

        #endregion GlobalFunctions

        #region Testimonial

        private IQueryable<TestimonialODTO> GetTestimonial(int id, string fullName, int langId)
        {
            return from x in _context.Testimonials
                   .Include(x => x.Language)
                   where (id == 0 || x.TestimonialId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   && (string.IsNullOrEmpty(fullName) || x.FullName.StartsWith(fullName))
                   select _mapper.Map<TestimonialODTO>(x);
        }

        public async Task<List<TestimonialODTO>> Get(int id)
        {
            return await GetTestimonial(id, null, 0).AsNoTracking().ToListAsync();
        }

        public async Task<List<TestimonialODTO>> GetTestimonialByLanguage(int langId)
        {
            return await GetTestimonial(0, null, langId).AsNoTracking().ToListAsync();
        }

        public async Task<List<TestimonialODTO>> EditTestimonial(TestimonialIDTO testimonialIDTO)
        {
            var testimonial = _mapper.Map<Testimonial>(testimonialIDTO);
            testimonial.TestimonialId = 0;
            _context.Entry(testimonial).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await Get(testimonial.TestimonialId);
        }

        public async Task<List<TestimonialODTO>> AddTest(TestimonialIDTO testimonialIDTO)
        {
            var testimonial = _mapper.Map<Testimonial>(testimonialIDTO);
            _context.Testimonials.Add(testimonial);
            await SaveContextChangesAsync();
            return await Get(testimonial.TestimonialId);
        }

        public async Task<List<TestimonialODTO>> DeleteTestimonial(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);
            if (testimonial == null) return null;
            var testimonialODTO = await Get(id);
            _context.Testimonials.Remove(testimonial);
            await SaveContextChangesAsync();
            return testimonialODTO;
        }

        #endregion Testimonial

        #region Language

        private IQueryable<LanguageODTO> GetLanguage(int id, string languageName)
        {
            return from x in _context.Languages
                   where (id == 0 || x.LanguageId == id)
                   && (string.IsNullOrEmpty(languageName) || x.LanguageName.StartsWith(languageName))
                   select _mapper.Map<LanguageODTO>(x);
        }

        public async Task<LanguageODTO> GetLanguageById(int id)
        {
            return await GetLanguage(id, null).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<LanguageODTO> EditLanguage(LanguageIDTO languageIDTO)
        {
            var language = _mapper.Map<Language>(languageIDTO);

            _context.Entry(language).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetLanguageById(language.LanguageId);
        }

        public async Task<LanguageODTO> AddLanguage(LanguageIDTO languageIDTO)
        {
            var language = _mapper.Map<Language>(languageIDTO);
            language.LanguageId = 0;
            _context.Languages.Add(language);

            await SaveContextChangesAsync();

            return await GetLanguageById(language.LanguageId);
        }

        public async Task<LanguageODTO> DeleteLanguage(int id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null) return null;

            var languageODTO = await GetLanguageById(id);
            _context.Languages.Remove(language);
            await SaveContextChangesAsync();
            return languageODTO;
        }

        #endregion Language

        #region DataType

        private IQueryable<DataTypeODTO> GetDataType(int id, string dataTypeName)
        {
            return from x in _context.DataTypes
                   where (id == 0 || x.DataTypeId == id)
                   && (string.IsNullOrEmpty(dataTypeName) || x.DataTypeName.StartsWith(dataTypeName))
                   select _mapper.Map<DataTypeODTO>(x);
        }

        public async Task<DataTypeODTO> GetDataTypeById(int id)
        {
            return await GetDataType(id, null).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<DataTypeODTO> EditDataType(DataTypeIDTO dataTypeIDTO)
        {
            var dataType = _mapper.Map<DataType>(dataTypeIDTO);

            _context.Entry(dataType).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetDataTypeById(dataType.DataTypeId);
        }

        public async Task<DataTypeODTO> AddDataType(DataTypeIDTO dataTypeIDTO)
        {
            var dataType = _mapper.Map<DataType>(dataTypeIDTO);

            dataType.DataTypeId = 0;

            _context.DataTypes.Add(dataType);

            await SaveContextChangesAsync();

            return await GetDataTypeById(dataType.DataTypeId);
        }

        public async Task<DataTypeODTO> DeleteDataType(int id)
        {
            var dataType = await _context.DataTypes.FindAsync(id);
            if (dataType == null) return null;

            var dataTypeODTO = await GetDataTypeById(id);
            _context.DataTypes.Remove(dataType);
            await SaveContextChangesAsync();
            return dataTypeODTO;
        }

        #endregion DataType

        #region NavigationSettings

        private IQueryable<NavigationSettingsODTO> GetNavigationSettings(int id, int langId)
        {
            return from x in _context.NavigationSettings
                   .Include(x => x.Language)
                   where (id == 0 || x.NavigationSettingsId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<NavigationSettingsODTO>(x);
        }

        public async Task<NavigationSettingsODTO> GetNavigationSettingsById(int id)
        {
            return await GetNavigationSettings(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<NavigationSettingsODTO>> GetNavigationSettingsByLangId(int langId)
        {
            return await GetNavigationSettings(0, langId).ToListAsync();
        }

        public async Task<NavigationSettingsODTO> EditNavigationSettings(NavigationSettingsIDTO navigationSettingsIDTO)
        {
            var navigationSettings = _mapper.Map<NavigationSettings>(navigationSettingsIDTO);

            _context.Entry(navigationSettings).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetNavigationSettingsById(navigationSettings.NavigationSettingsId);
        }

        public async Task<NavigationSettingsODTO> AddNavigationSettings(NavigationSettingsIDTO navigationSettingsIDTO)
        {
            var navigationSettings = _mapper.Map<NavigationSettings>(navigationSettingsIDTO);

            navigationSettings.NavigationSettingsId = 0;

            _context.NavigationSettings.Add(navigationSettings);

            await SaveContextChangesAsync();

            return await GetNavigationSettingsById(navigationSettings.NavigationSettingsId);
        }

        public async Task<NavigationSettingsODTO> DeleteNavigationSettings(int id)
        {
            var navigationSettings = await _context.NavigationSettings.FindAsync(id);
            if (navigationSettings == null) return null;

            var navigationSettingsODTO = await GetNavigationSettingsById(id);
            _context.NavigationSettings.Remove(navigationSettings);
            await SaveContextChangesAsync();
            return navigationSettingsODTO;
        }

        #endregion NavigationSettings

        #region FooterSettings

        private IQueryable<FooterSettings> GetFooterSettings(int id, int langId)
        {
            return from x in _context.FooterSettings
                   where (id == 0 || x.FooterSettingsId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select x;
        }

        public async Task<FooterSettingsODTO> GetFooterSettingsById(int id)
        {
            return await _mapper.ProjectTo<FooterSettingsODTO>(GetFooterSettings(id, 0)).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<FooterSettingsODTO>> GetFooterSettingsByLangId(int langId)
        {
            return await _mapper.ProjectTo<FooterSettingsODTO>(GetFooterSettings(0, langId)).ToListAsync();
        }

        public async Task<FooterSettingsODTO> EditFooterSettings(FooterSettingsIDTO footerSettingsIDTO)
        {
            var footerSettings = _mapper.Map<FooterSettings>(footerSettingsIDTO);
            _context.Entry(footerSettings).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetFooterSettingsById(footerSettings.FooterSettingsId);
        }

        public async Task<FooterSettingsODTO> AddFooterSettings(FooterSettingsIDTO footerSettingsIDTO)
        {
            var footerSettings = _mapper.Map<FooterSettings>(footerSettingsIDTO);

            footerSettings.FooterSettingsId = 0;

            _context.FooterSettings.Add(footerSettings);

            await SaveContextChangesAsync();

            return await GetFooterSettingsById(footerSettings.FooterSettingsId);
        }

        public async Task<FooterSettingsODTO> DeleteFooterSettings(int id)
        {
            var footerSettings = await _context.FooterSettings.FindAsync(id);
            if (footerSettings == null) return null;

            var footerSettingsODTO = await GetFooterSettingsById(id);
            _context.FooterSettings.Remove(footerSettings);
            await SaveContextChangesAsync();
            return footerSettingsODTO;
        }

        #endregion FooterSettings

        #region ReviewAttribute

        private IQueryable<ReviewAttributeODTO> GetReviewAttr(int id)
        {
            return from x in _context.ReviewAttributes
                   where (id == 0 || x.ReviewAttributeId == id)
                   select _mapper.Map<ReviewAttributeODTO>(x);
        }

        public async Task<ReviewAttributeODTO> GetReviewAttribute(int id)
        {
            return await GetReviewAttr(id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<ReviewAttributeODTO> EditReviewAttribute(ReviewAttributeIDTO reviewAttributeIDTO)
        {
            var reviewAttribute = _mapper.Map<ReviewAttribute>(reviewAttributeIDTO);

            _context.Entry(reviewAttribute).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetReviewAttribute(reviewAttribute.ReviewAttributeId);
        }

        public async Task<ReviewAttributeODTO> AddReviewAttribute(ReviewAttributeIDTO reviewAttributeIDTO)
        {
            var reviewAttribute = _mapper.Map<ReviewAttribute>(reviewAttributeIDTO);
            reviewAttribute.ReviewAttributeId = 0;
            _context.ReviewAttributes.Add(reviewAttribute);

            await SaveContextChangesAsync();

            return await GetReviewAttribute(reviewAttribute.ReviewAttributeId);
        }

        public async Task<ReviewAttributeODTO> DeleteReviewAttribute(int id)
        {
            var reviewAttribute = await _context.ReviewAttributes.FindAsync(id);
            if (reviewAttribute == null) return null;

            var reviewAttributeODTO = await GetReviewAttribute(id);
            _context.ReviewAttributes.Remove(reviewAttribute);
            await SaveContextChangesAsync();
            return reviewAttributeODTO;
        }

        #endregion ReviewAttribute

        #region UrlTable

        private IQueryable<UrlTableODTO> GetUrlTable(int id, int dataTypeId)
        {
            return from x in _context.UrlTables
                   .Include(x => x.DataType)
                   where (id == 0 || x.UrlTableId == id)
                   && (dataTypeId == 0 || x.DataTypeId == dataTypeId)
                   select _mapper.Map<UrlTableODTO>(x);
        }

        public async Task<UrlTableODTO> GetUrlTableById(int id)
        {
            return await GetUrlTable(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<UrlTableODTO>> GetUrlTableByDataTypeId(int dataTypeId)
        {
            return await GetUrlTable(0, dataTypeId).ToListAsync();
        }

        public async Task<UrlTableODTO> EditUrlTable(UrlTableIDTO urlTableIDTO)
        {
            var urlTable = _mapper.Map<UrlTable>(urlTableIDTO);

            _context.Entry(urlTable).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetUrlTableById(urlTable.UrlTableId);
        }

        public async Task<UrlTableODTO> AddUrlTable(UrlTableIDTO urlTableIDTO)
        {
            var urlTable = _mapper.Map<UrlTable>(urlTableIDTO);

            urlTable.UrlTableId = 0;

            _context.UrlTables.Add(urlTable);

            await SaveContextChangesAsync();

            return await GetUrlTableById(urlTable.UrlTableId);
        }

        public async Task<UrlTableODTO> DeleteUrlTable(int id)
        {
            var urlTable = await _context.UrlTables.FindAsync(id);
            if (urlTable == null) return null;

            var urlTableODTO = await GetUrlTableById(id);
            _context.UrlTables.Remove(urlTable);
            await SaveContextChangesAsync();
            return urlTableODTO;
        }

        #endregion UrlTable

        #region Links

        private IQueryable<LinkODTO> GetLinks(int id, string key, int langId)
        {
            return from x in _context.Links
                   .Include(x => x.UrlTable)
                   .Include(x => x.Language)
                   where (id == 0 || x.LinkId == id)
                   && (string.IsNullOrEmpty(key) || x.Key.StartsWith(key))
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<LinkODTO>(x);
        }

        public async Task<LinkODTO> GetLinkById(int id)
        {
            return await GetLinks(id, null, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<LinkODTO>> GetLinkByKeyAndLang(string key, int langId)
        {
            return await GetLinks(0, key, langId).ToListAsync();
        }

        public async Task<List<LinkODTO>> GetLinkByLang(int langId)
        {
            return await GetLinks(0, null, langId).ToListAsync();
        }

        public async Task<LinkODTO> EditLink(LinkIDTO linkIDTO)
        {
            var links = _mapper.Map<Links>(linkIDTO);

            _context.Entry(links).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetLinkById(links.LinkId);
        }

        public async Task<LinkODTO> AddLink(LinkIDTO linkIDTO)
        {
            var links = _mapper.Map<Links>(linkIDTO);
            links.LinkId = 0;
            _context.Links.Add(links);

            await SaveContextChangesAsync();

            return await GetLinkById(links.LinkId);
        }

        public async Task<LinkODTO> DeleteLink(int id)
        {
            var links = await _context.Links.FindAsync(id);
            if (links == null) return null;

            var LinkODTO = await GetLinkById(id);
            _context.Links.Remove(links);
            await SaveContextChangesAsync();
            return LinkODTO;
        }

        #endregion Links

        #region CashBack

        private IQueryable<CashBackODTO> GetCashBack(int id, int langId)
        {
            return from x in _context.CashBacks
                   .Include(x => x.Language)
                   .Include(x => x.Review)
                   where (id == 0 || x.CashBackId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<CashBackODTO>(x);
        }

        public async Task<List<CashBackODTO>> GetCashBackByLangId(int langId)
        {
            return await GetCashBack(0, langId).ToListAsync();
        }

        public async Task<CashBackODTO> GetCashBackById(int id)
        {
            return await GetCashBack(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<GetCashbackCampOfferODTO> Get(int id, bool isCampaign)
        {
            List<ReviewContentDropdownODTO> reviewsList = await ListOfReviews();

            var cashback = new GetCashbackCampOfferODTO();

            try
            {
                cashback = await (from x in _context.CashBacks
                                  .Include(x => x.Language)
                                  .Include(x => x.Review)
                                  where (id == 0 || x.CashBackId == id)
                                  && x.IsCampaign == isCampaign
                                  select _mapper.Map<GetCashbackCampOfferODTO>(x)).SingleOrDefaultAsync();

                if (cashback != null)
                {
                    cashback.reviews = new List<ReviewContentDropdownODTO>();
                    cashback.reviews = reviewsList;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return cashback;
        }

        public async Task<List<CashbackListODTO>> CashbackList(int langId, bool isCampaign)
        {
            var cashbacks = new List<CashbackListODTO>();
            if (isCampaign)
            {
                cashbacks = await (from x in _context.CashBacks
                                   where x.LanguageId == langId && x.IsCampaign == isCampaign
                                   select new CashbackListODTO
                                   {
                                       ReviewId = x.ReviewId,
                                       Name = x.Review.Name,
                                       CashBackId = x.CashBackId,
                                       Valid_Until = x.Valid_Until
                                   }).OrderByDescending(x => x.Valid_Until).ToListAsync();
            }
            else
            {
                cashbacks = await (from x in _context.CashBacks
                                   where x.LanguageId == langId && x.IsCampaign == isCampaign
                                   join r in _context.Review on x.ReviewId equals r.ReviewId
                                   select new CashbackListODTO
                                   {
                                       ReviewId = x.ReviewId,
                                       Name = x.Review.Name,
                                       CashBackId = x.CashBackId,
                                       RatingCalculated = r.RatingCalculated
                                   }).OrderByDescending(x => x.CashBackId).ToListAsync();
            }
            return cashbacks;
        }

        public async Task<CampaignBonusODTO> GetCampaignBonus(int langId)
        {
            var offer = await (from x in _context.CashBacks
                               join r in _context.Review on x.ReviewId equals r.ReviewId into a
                               from d in a.DefaultIfEmpty()
                               where d.LanguageId == langId && x.IsCampaign == false
                               select new GetCampaignBonusODTO
                               {
                                   CashBackId = x.CashBackId,
                                   ReviewId = d.ReviewId,
                                   Exclusive = x.Exclusive,
                                   Name = d.Name,
                                   Logo = d.Logo,
                                   Count = d.Count,
                                   CashbackCta = x.CashBack_ca,
                                   Stars = (decimal)(((d.RiskAndReturn != null ? d.RiskAndReturn : 0) + (d.Usability != null ? d.Usability : 0) +
                                               (d.Liquidity != null ? d.Liquidity : 0) + (d.Support != null ? d.Support : 0)) / 4),
                                   ExternalLinkKey = d.Name.ToLower(),
                                   //datatype treba biti 'review'
                                   ReviewUrlId = _context.Routes.FirstOrDefault(e => e.DataTypeId == 1 && e.ReviewId == d.ReviewId).UrlTableId,
                                   Terms = x.CashBack_terms,
                                   ReviewBoxThree = new List<ReviewBoxThreeODTO> { new ReviewBoxThreeODTO
                             {
                                 BuybackGuarantee=d.BuybackGuarantee,
                                 AutoInvest=d.AutoInvest,
                                 Secondarymarket=d.SecondaryMarket,
                                 Cashback=d.CashbackBonus,
                                 Promotion=d.Promotion
                             } },
                                   ReviewBoxFour = new List<ReviewBoxFourODTO> { new ReviewBoxFourODTO
                             {
                                 MinInvestment=d.DiversificationMinInvest,
                                 Country=d.Countries,
                                 LoanOriginators=d.LoanOriginators,
                                 LoanType=d.LoanType,
                                 LoanPeriod=string.Format("{0} - {1}", d.MinLoanPerion, d.MaxLoanPerion),
                                 Interest=d.InterestRange,
                                 Currency=d.StatisticsCurrency
                             } },
                                   //      ReviewBoxFive = new List<ReviewBoxFiveODTO> { new ReviewBoxFiveODTO
                                   //{
                                   //    //TODO pros=> BILO JE VISE Benefita sad su to ReviewAttr
                                   //    //TODO cons=> BILO JE VISE Disadvantage sad su to ReviewAttr
                                   //} }
                               }).OrderByDescending(e => e.Stars).ToListAsync();

            var campaign = await (from x in _context.CashBacks
                                  join r in _context.Review on x.ReviewId equals r.ReviewId into a
                                  from d in a.DefaultIfEmpty()
                                  where d.LanguageId == langId && x.IsCampaign == true
                                  select new GetCampaignBonusODTO
                                  {
                                      CashBackId = x.CashBackId,
                                      ReviewId = d.ReviewId,
                                      Exclusive = x.Exclusive,
                                      Name = d.Name,
                                      Logo = d.Logo,
                                      Count = d.Count,
                                      CashbackCta = x.CashBack_ca,
                                      Stars = (decimal)(((d.RiskAndReturn != null ? d.RiskAndReturn : 0) + (d.Usability != null ? d.Usability : 0) +
                                         (d.Liquidity != null ? d.Liquidity : 0) + (d.Support != null ? d.Support : 0)) / 4),
                                      ExternalLinkKey = d.Name.ToLower(),
                                      //datatype treba biti 'review'
                                      ReviewUrlId = _context.Routes.FirstOrDefault(e => e.DataTypeId == 1 && e.ReviewId == d.ReviewId).UrlTableId,
                                      Terms = x.CashBack_terms,
                                  }).OrderByDescending(e => e.Stars).ToListAsync();

            var cashback = new CampaignBonusODTO
            {
                CashBackOffer = offer,
                CashBackCampaign = campaign
            };

            return cashback;
        }

        public async Task<CashBackODTO> EditCashBack(CashBackIDTO cashBackIDTO)
        {
            var cashBack = _mapper.Map<CashBack>(cashBackIDTO);
            if (cashBack.IsCampaign)
            {
                if (cashBack.Valid_Until != null && cashBack.Valid_Until > DateTime.Now)
                {
                    cashBack.Exclusive = null;
                }
                else
                {
                    throw new System.Exception("Polje Valid_until mora biti popunjeno i vece od trenutnog vremena.");
                }
            }
            else
            {
                if (cashBack.Exclusive != null)
                {
                    cashBack.Valid_Until = null;
                }
                else
                {
                    throw new NoNullAllowedException();
                }
            }
            _context.Entry(cashBack).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetCashBackById(cashBack.CashBackId);
        }

        public async Task<CashBackODTO> AddCashBack(CashBackIDTO cashBackIDTO)
        {
            var cashBack = _mapper.Map<CashBack>(cashBackIDTO);
            if (cashBack.IsCampaign)
            {
                if (cashBack.Valid_Until != null && cashBack.Valid_Until > DateTime.Now)
                {
                    cashBack.Exclusive = null;
                }
                else
                {
                    throw new System.Exception("Vreme mora biti popunjeno i vece od trenutnog.");
                }
            }
            else
            {
                if (cashBack.Exclusive != null)
                {
                    cashBack.Valid_Until = null;
                }
                else
                {
                    throw new NoNullAllowedException();
                }
            }
            cashBack.CashBackId = 0;
            _context.CashBacks.Add(cashBack);

            await SaveContextChangesAsync();

            return await GetCashBackById(cashBack.CashBackId);
        }

        public async Task<CashBackODTO> DeleteCashBack(int id)
        {
            var cashBack = await _context.CashBacks.FindAsync(id);
            if (cashBack == null) return null;

            var cashBackODTO = await GetCashBackById(id);
            _context.CashBacks.Remove(cashBack);
            await SaveContextChangesAsync();
            return cashBackODTO;
        }

        #endregion CashBack

        #region Routes

        private IQueryable<RoutesODTO> GetRoutes(int id, int languageId)
        {
            return from x in _context.Routes
                   .Include(x => x.Language)
                   .Include(x => x.DataType)
                   .Include(x => x.UrlTable)
                   .Include(x => x.Review)
                   where (id == 0 || x.RoutesId == id)
                   && (languageId == 0 || x.LanguageId == languageId)
                   select _mapper.Map<RoutesODTO>(x);
        }

        public async Task<RoutesODTO> GetRoutesById(int id)
        {
            return await GetRoutes(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<RoutesODTO>> GetRoutesByLanguageId(int langId)
        {
            return await GetRoutes(0, langId).ToListAsync();
        }

        public async Task<List<RoutesODTO>> GetAllRoutes()
        {
            return await GetRoutes(0, 0).ToListAsync();
        }

        public async Task<RoutesODTO> EditRoute(RoutesIDTO routesIDTO)
        {
            var routes = _mapper.Map<Routes>(routesIDTO);

            _context.Entry(routes).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetRoutesById(routes.RoutesId);
        }

        public async Task<RoutesODTO> AddRoute(RoutesIDTO routesIDTO)
        {
            var routes = _mapper.Map<Routes>(routesIDTO);
            routes.RoutesId = 0;
            _context.Routes.Add(routes);

            await SaveContextChangesAsync();

            return await GetRoutesById(routes.RoutesId);
        }

        public async Task<RoutesODTO> DeleteRoute(int id)
        {
            var routes = await _context.Routes.FindAsync(id);
            if (routes == null) return null;

            var routesODTO = await GetRoutesById(id);
            _context.Routes.Remove(routes);
            await SaveContextChangesAsync();
            return routesODTO;
        }

        public async Task<List<GetDropdownValuesODTO>> GetDropdownValues(string key)
        {
            var reviews = new List<GetDropdownValuesODTO>();

            reviews = await (from x in _context.Review
                             select new GetDropdownValuesODTO
                             {
                                 Value = "review_" + x.ReviewId.ToString(),
                                 Name = x.Name,
                             }).OrderByDescending(x => x.Value).ToListAsync();

            var pages = new List<GetDropdownValuesODTO>();

            pages = await (from x in _context.Pages
                           select new GetDropdownValuesODTO
                           {
                               Value = "pages__" + x.PageId.ToString(),
                               Name = x.PageTitle,
                           }).OrderByDescending(x => x.Value).ToListAsync();

            if (key.ToLower() == "review")
            {
                return reviews;
            }
            if (key.ToLower() == "academy" || key.ToLower() == "cashback-bonus" || key.ToLower() == "general")
            {
                return pages;
            }
            if (key.ToLower() == "specific")
            {
                return reviews.Concat(pages).ToList();
            }

            return reviews.Concat(pages).ToList();
        }

        #endregion Routes

        #region Serp

        private IQueryable<SerpODTO> GetSerp(int id, int dataTypeId)
        {
            return from x in _context.Serps
                   where (id == 0 || x.SerpId == id)
                   && (dataTypeId == 0 || x.DataTypeId == dataTypeId)
                   select _mapper.Map<SerpODTO>(x);
        }

        public async Task<SerpODTO> GetSerpById(int id)
        {
            return await GetSerp(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<SerpODTO>> GetByDataTypeId(int dataTypeId)
        {
            return await GetSerp(0, dataTypeId).ToListAsync();
        }

        public async Task<SerpODTO> EditSerp(SerpIDTO serpIDTO)
        {
            var serp = _mapper.Map<Serp>(serpIDTO);

            _context.Entry(serp).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetSerpById(serp.SerpId);
        }

        public async Task<SerpODTO> AddSerp(SerpIDTO serpIDTO)
        {
            var serp = _mapper.Map<Serp>(serpIDTO);
            serp.SerpId = 0;
            _context.Serps.Add(serp);

            await SaveContextChangesAsync();

            return await GetSerpById(serp.SerpId);
        }

        public async Task<SerpODTO> DeleteSerp(int id)
        {
            var serp = await _context.Serps.FindAsync(id);
            if (serp == null) return null;

            var serpODTO = await GetSerpById(id);
            _context.Serps.Remove(serp);
            await SaveContextChangesAsync();
            return serpODTO;
        }

        #endregion Serp

        #region FaqTitle

        private IQueryable<FaqTitleODTO> GetFaqTitle(int id, int pageId)
        {
            return from x in _context.FaqTitles
                   .Include(x => x.Page)
                   where (id == 0 || x.FaqTitleId == id)
                   && (pageId == 0 || x.PageId == pageId)
                   select _mapper.Map<FaqTitleODTO>(x);
        }

        public async Task<FaqTitleODTO> GetFaqTitleById(int id)
        {
            return await GetFaqTitle(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<GetFaqTitleByReviewIdODTO>> GetFaqTitleByReviewId(int reviewId)
        {
            return await (from x in _context.FaqTitles
                          where (reviewId == 0 || x.ReviewId == reviewId)
                          && x.ReviewId != null
                          select _mapper.Map<GetFaqTitleByReviewIdODTO>(x)).ToListAsync();
        }

        public async Task<List<GetFaqTitleByPageIdODTO>> GetFaqTitleByPageId(int pageId)
        {
            return await (from x in _context.FaqTitles
                          where (pageId == 0 || x.PageId == pageId)
                          && x.PageId != null
                          select _mapper.Map<GetFaqTitleByPageIdODTO>(x)).ToListAsync();
        }

        public async Task<FaqTitleODTO> EditFaqTitle(FaqTitleIDTO faqTitleIDTO)
        {
            var faqTitle = _mapper.Map<FaqTitle>(faqTitleIDTO);

            _context.Entry(faqTitle).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetFaqTitleById(faqTitle.FaqTitleId);
        }

        public async Task<FaqTitleODTO> AddFaqTitle(FaqTitleIDTO faqTitleIDTO)
        {
            var faqTitle = _mapper.Map<FaqTitle>(faqTitleIDTO);

            faqTitle.FaqTitleId = 0;
            _context.FaqTitles.Add(faqTitle);

            await SaveContextChangesAsync();

            return await GetFaqTitleById(faqTitle.FaqTitleId);
        }

        public async Task<FaqTitleODTO> DeleteFaqTitle(int id)
        {
            var faqTitle = await _context.FaqTitles.FindAsync(id);
            if (faqTitle == null) return null;

            var faqTitleODTO = await GetFaqTitleById(id);
            _context.FaqTitles.Remove(faqTitle);
            await SaveContextChangesAsync();
            return faqTitleODTO;
        }

        #endregion FaqTitle

        #region FaqList

        private IQueryable<FaqListODTO> GetFaqList(int id, int faqTitleId)
        {
            return from x in _context.FaqLists
                   .Include(x => x.FaqTitle)
                   where (id == 0 || x.FaqPageListId == id)
                   && (faqTitleId == 0 || x.FaqTitleId == faqTitleId)
                   select _mapper.Map<FaqListODTO>(x);
        }

        public async Task<FaqListODTO> GetFaqListById(int id)
        {
            return await GetFaqList(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<FaqListODTO>> GetFaqListByFaqTitleId(int faqTitleId)
        {
            return await GetFaqList(0, faqTitleId).ToListAsync();
        }

        public async Task<FaqListODTO> EditFaqList(FaqListIDTO faqListIDTO)
        {
            var faqList = _mapper.Map<FaqList>(faqListIDTO);

            _context.Entry(faqList).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetFaqListById(faqList.FaqPageListId);
        }

        public async Task<FaqListODTO> AddFaqList(FaqListIDTO faqListIDTO)
        {
            var faqList = _mapper.Map<FaqList>(faqListIDTO);

            faqList.FaqPageListId = 0;
            _context.FaqLists.Add(faqList);

            await SaveContextChangesAsync();

            return await GetFaqListById(faqList.FaqPageListId);
        }

        public async Task<FaqListODTO> DeleteFaqList(int id)
        {
            var faqList = await _context.FaqLists.FindAsync(id);
            if (faqList == null) return null;

            var faqListODTO = await GetFaqListById(id);
            _context.FaqLists.Remove(faqList);
            await SaveContextChangesAsync();
            return faqListODTO;
        }

        #endregion FaqList

        #region Page

        private IQueryable<PageODTO> GetPage(int id, int languageId, int dataTypeId)
        {
            return from x in _context.Pages
                   .Include(x => x.Language)
                   .Include(x => x.DataType)
                   .Include(x => x.Review)
                   where (id == 0 || x.PageId == id)
                   && (languageId == 0 || x.LanguageId == languageId)
                   && (dataTypeId == 0 || x.DataTypeId == dataTypeId)
                   select _mapper.Map<PageODTO>(x);
        }

        public async Task<PageODTO> GetPageById(int id)
        {
            return await GetPage(id, 0, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<GetPageODTO> GetItem(int id)
        {
            List<ReviewContentDropdownODTO> reviews = await ListOfReviews();
            var page = await _context.Pages.FirstOrDefaultAsync(e => e.PageId == id);
            var popularArticles = _context.Academies.Select(e => new PopularArticlesODTO
            {
                Value = e.AcademyId,
                Label = e.Title
            }).ToList();

            var retVal = new GetPageODTO
            {
                PageId = page.PageId,
                Page_Title = page.PageTitle,
                SerpId = page.SerpId,
                DataTypeId = page.DataTypeId,
                ReviewContentDropdowns = reviews,
                ReviewId = (int)page.ReviewId,
                PopularArticles = popularArticles,
                SelectedLanguage = page.LanguageId,
                SelectedPopularArticles = _context.PageArticles.Where(e => e.PageId == page.PageId).Select(e => e.AcademyId).ToList(),
            };

            return retVal;
        }

        public async Task<List<GetPageListODTO>> GetList(int langId)
        {
            var pages = new List<GetPageListODTO>();

            pages = await (from x in _context.Pages
                           .Include(x => x.DataType)
                           where x.LanguageId == langId
                           select new GetPageListODTO
                           {
                               PageId = x.PageId,
                               Page_Title = x.PageTitle,
                               DataTypeId = x.DataTypeId,
                               DataTypeName = x.DataType.DataTypeName
                           }).OrderByDescending(x => x.PageId).ToListAsync();

            return pages;
        }

        public async Task<GetItemContentODTO> GetItemContent(int? id, int urlId, int langId)
        {
            try
            {
                if (id != null)
                {
                    var page = _context.Pages.FirstOrDefault(e => e.PageId == id);

                    var retVal = new GetItemContentODTO
                    {
                        PageId = page.PageId,
                        Content = page.Content,
                    };

                    return retVal;
                }
                else
                {
                    var route = await (from x in _context.Routes
                                       where x.LanguageId == langId
                                       && x.UrlTableId == urlId
                                       select x).FirstOrDefaultAsync();

                    if (route.ReviewId == null) throw new Exception("No data available.");
                    var pd = _context.Pages.FirstOrDefault(e => e.ReviewId == route.RoutesId);
                    var retVal = new GetItemContentODTO
                    {
                        PageId = pd.PageId,
                        Content = pd.Content,
                    };
                    return retVal;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //TODO /Pages/GetPageContent
        public async Task<List<PageODTO>> GetPageByLanguageId(int id)
        {
            return await GetPage(0, id, 0).ToListAsync();
        }

        public async Task<List<PageODTO>> GetPageByDataTypeId(int id)
        {
            return await GetPage(0, 0, id).ToListAsync();
        }

        public async Task<PageODTO> EditPage(PageIDTO pageIDTO)
        {
            var page = _mapper.Map<Page>(pageIDTO);

            _context.Entry(page).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetPageById(page.PageId);
        }

        public async Task<PageODTO> AddPage(PageIDTO pageIDTO)
        {
            var page = _mapper.Map<Page>(pageIDTO);

            page.PageId = 0;
            _context.Pages.Add(page);

            await SaveContextChangesAsync();

            return await GetPageById(page.PageId);
        }

        public async Task<PageODTO> DeletePage(int id)
        {
            //TODO Videti sa frontom da li im treba brisanje u nazad

            //var pageArtical = await _context.PageArticles.Where(x => x.PageId == id).Select(x => x.PageId).ToListAsync();
            //var faqTitles = await _context.FaqTitles.Where(x => x.PageId == id).Select(x => x.PageId).ToListAsync();
            //var faqTitlesId = await _context.FaqTitles.Where(x => x.PageId == id).Select(x => x.FaqTitleId).ToListAsync();

            //if (pageArtical.Count != 0)
            //{
            //    foreach (var item in pageArtical)
            //    {
            //        var pageart = await _context.PageArticles.Where(x => x.PageId == item).FirstOrDefaultAsync();
            //        _context.PageArticles.Remove(pageart);
            //        await SaveContextChangesAsync();
            //    }
            //}

            //if (faqTitlesId.Count != 0)
            //{
            //    foreach (var item in faqTitlesId)
            //    {
            //        var faqList = await _context.FaqLists.Where(x => x.FaqTitleId == item).FirstOrDefaultAsync();
            //        _context.FaqLists.Remove(faqList);
            //        await SaveContextChangesAsync();
            //    }
            //}

            //if (faqTitles.Count != 0)
            //{
            //    foreach (var item in faqTitles)
            //    {
            //        var faq = await _context.FaqTitles.Where(x => x.PageId == item).FirstOrDefaultAsync();
            //        _context.FaqTitles.Remove(faq);
            //        await SaveContextChangesAsync();
            //    }
            //}

            var page = await _context.Pages.FindAsync(id);
            if (page == null) return null;

            var pageODTO = await GetPageById(id);
            _context.Pages.Remove(page);
            await SaveContextChangesAsync();
            return pageODTO;
        }

        #endregion Page

        #region Review

        private IQueryable<ReviewODTO> GetReview(int id, int urlId)
        {
            return from x in _context.Review
                   join y in _context.Routes on x.ReviewId equals y.ReviewId
                   where (id == 0 || x.ReviewId == id
                   && (urlId == 0 || y.UrlTableId == urlId))
                   select _mapper.Map<ReviewODTO>(x);
        }

        public async Task<ReviewODTO> GetReviewById(int id)
        {
            return await GetReview(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<GetReviewsByRouteODTO> GetReviewsByRoute(int urlId, int langId)
        {
            int UrlReviewId = _context.Routes.FirstOrDefault(x => x.UrlTableId == urlId && x.LanguageId == langId).ReviewId;
            var review = _context.Review.FirstOrDefault(x => x.ReviewId == UrlReviewId);

            var ReviewBoxOnes = new List<ReviewBoxOneODTO>();
            ReviewBoxOnes.Add(new ReviewBoxOneODTO
            {
                ReviewId = review.ReviewId,
                Name = review.Name,
                Interest = review.Interest,
                RatingCalculated = review.RatingCalculated,
                SecuredBy = review.SecuredBy,
                SecuredByCheck = review.SecuredByCheck,
                Bonus = review.Bonus,
                CustomMessage = review.CustomMessage,
                CompareButton = review.CompareButton,
                Logo = review.Logo,
                Recommended = review.Recommended
            });
            var ReviewBoxTwos = new List<ReviewBoxTwoODTO>();
            ReviewBoxTwos.Add(new ReviewBoxTwoODTO
            {
                //TODO highlights => BILO JE VISE HIGHLIGHTA sad su to ReviewAttr
                Ratings = new decimal?[] { review.RiskAndReturn, review.Usability, review.Liquidity, review.Support }
            });

            var ReviewBoxThrees = new List<ReviewBoxThreeODTO>();
            ReviewBoxThrees.Add(new ReviewBoxThreeODTO
            {
                BuybackGuarantee = review.BuybackGuarantee,
                AutoInvest = review.AutoInvest,
                Secondarymarket = review.SecondaryMarket,
                Cashback = review.CashbackBonus,
                Promotion = review.Promotion
            });
            var reviewBoxFours = new List<ReviewBoxFourODTO>();
            reviewBoxFours.Add(new ReviewBoxFourODTO
            {
                MinInvestment = review.DiversificationMinInvest,
                Country = review.Countries,
                LoanOriginators = review.LoanOriginators,
                LoanType = review.LoanType,
                LoanPeriod = string.Format("{0} - {1}", review.MinLoanPerion, review.MaxLoanPerion),
                Interest = review.InterestRange,
                Currency = review.StatisticsCurrency
            });
            var reviewBoxFives = new List<ReviewBoxFiveODTO>();
            reviewBoxFives.Add(new ReviewBoxFiveODTO
            {
                //TODO pros=> BILO JE VISE Benefita sad su to ReviewAttr
                //TODO cons=> BILO JE VISE Disadvantage sad su to ReviewAttr
            });
            var statistics = new List<StatisticsODTO>();
            statistics.Add(new StatisticsODTO
            {
                OperatingSince = review.OperatingSince,
                Investors = review.NumberOfInvestors,
                InvestorsEarnings = review.Earnings,
                AveragePortfolio = review.PortfolioSize,
                TotalInvested = review.TotalLoanValue,
                FinancialReport = review.FinancialReport,
                InvestorsLoss = review.InvestorsLoss,
                StatisticsOtherCurrency = review.StatisticsOtherCurrency,
                ReportLink = review.ReportLink,
                StatisticsCurrency = review.StatisticsCurrency
            });
            var ComapanyInfo = new List<CompanyInfoODTO>();
            ComapanyInfo.Add(new CompanyInfoODTO
            {
                Name = review.Name,
                Address = review.Address,
                Phone = review.Phone,
                Email = review.Email,
                LiveChat = review.LiveChat,
                OpeningHours = review.OpeningHours,
                SocialMedia = new int?[] { review.FacebookUrl, review.TwitterUrl, review.LinkedInUrl, review.YoutubeUrl, review.InstagramUrl },
            });
            var data = new GetReviewsByRouteODTO
            {
                ReviewId = review.ReviewId,
                Name = review.Name,
                UpdatedDate = review.UpdatedDate,
                Availability = review.Availability,
                SerpId = review.SerpId,
                RiskReturn = review.RiskAndReturn,
                Address = review.OfficeAddress,
                Content = review.ReviewContent,
                Count = (review.Count != null) ? review.Count : 0,
                ReviewBoxOne = ReviewBoxOnes,
                ReviewBoxTwo = ReviewBoxTwos,
                ReviewBoxThree = ReviewBoxThrees,
                ReviewBoxFour = reviewBoxFours,
                ReviewBoxFive = reviewBoxFives,
                Statistics = statistics,
                CompanyInfo = ComapanyInfo
            };

            return data;
        }

        public async Task<List<ReviewContentDropdownODTO>> GetListOfReviews()
        {
            List<ReviewContentDropdownODTO> reviews = await ListOfReviews();
            return reviews;
        }

        public async Task AddCount(string name)
        {
            var reviewCount = await _context.Review.Where(x => x.Name.ToLower() == name.ToLower()).SingleOrDefaultAsync();

            if (reviewCount != null)
            {
                if (reviewCount.Count != null)
                {
                    reviewCount.Count += 1;
                }
                else
                {
                    reviewCount.Count = 1;
                }
                _context.Entry(reviewCount).State = EntityState.Modified;
                await SaveContextChangesAsync();
            }
        }

        public async Task<List<ReviewContentDropdownODTO>> GetListOfReviewsByLang(int langId)
        {
            List<ReviewContentDropdownODTO> reviews = await (from x in _context.Review
                                                             where x.LanguageId == langId
                                                             select new ReviewContentDropdownODTO
                                                             {
                                                                 Value = x.ReviewId,
                                                                 Label = x.Name,
                                                                 Rating = x.RatingCalculated
                                                             }).OrderByDescending(x => x.Rating).ToListAsync();
            return reviews;
        }

        public async Task<List<GetParentReviewODTO>> GetParentReview(int langId)
        {
            var lang = _context.Languages.First(e => e.LanguageId == langId);
            var ReviewRoute = (from x in _context.Review
                               join r in _context.Routes on x.ReviewId equals r.ReviewId into c
                               from a in c.DefaultIfEmpty()
                                   //TODO DataTypeId mora biti REVIEW
                               where (a.DataTypeId == 1 && x.LanguageId == langId)
                               select new GetParentReviewODTO
                               {
                                   ReviewId = x.ReviewId,
                                   Stars = x.RatingCalculated,
                                   Logo = x.Logo,
                                   Name = x.Name,
                                   LinkTo = a.UrlTableId,
                                   NewPlatform = x.NewPlatform,
                                   Interest = x.Interest,
                                   SecuredBy = x.SecuredBy,
                                   Count = (x.Count != null) ? x.Count : 0,
                                   Guarantee = x.BuybackGuarantee ? "buyback guarantee" : x.PersonalGuarantee ? "personal guarantee " : x.Mortage ? "mortgage" : x.Collateral ? "collateral" :
                                              x.NoProtection ? "not secured" : x.CryptoAssets ? "cryptoassets" : "",
                                   IsSecured = !x.NotSecured,
                                   ExternalLinkKey = x.Name.ToLower(),
                                   CustomMessage = x.CustomMessage,
                                   Recommended = x.Recommended,
                                   CompareButton = x.CompareButton ? true : false,
                               }).ToListAsync();
            return await ReviewRoute;
        }

        public async Task<ReviewODTO> EditReview(ReviewIDTO reviewIDTO)
        {
            var review = _mapper.Map<Review>(reviewIDTO);

            _context.Entry(review).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetReviewById(review.ReviewId);
        }

        public async Task<ReviewODTO> AddReview(ReviewIDTO reviewIDTO)
        {
            var review = _mapper.Map<Review>(reviewIDTO);
            review.ReviewId = 0;
            _context.Review.Add(review);

            await SaveContextChangesAsync();

            return await GetReviewById(review.ReviewId);
        }

        public async Task<ReviewODTO> DeleteReview(int id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review == null) return null;

            var reviewODTO = await GetReviewById(id);
            _context.Review.Remove(review);
            await SaveContextChangesAsync();
            return reviewODTO;
        }

        #endregion Review

        #region Academy

        private IQueryable<AcademyODTO> GetAcademy(int id, int langId, string tag)
        {
            return from x in _context.Academies
                   .Include(x => x.Language)
                   .Include(x => x.Serp)
                   .Include(x => x.UrlTable)
                   where (id == 0 || x.AcademyId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   && (string.IsNullOrEmpty(tag) || x.Tag.StartsWith(tag))
                   select _mapper.Map<AcademyODTO>(x);
        }

        public async Task<AcademyODTO> GetAcademyById(int id)
        {
            return await GetAcademy(id, 0, null).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<AcademyODTO>> GetAcademyByLangId(int langId)
        {
            return await GetAcademy(0, langId, null).ToListAsync();
        }

        public async Task<List<AcademyODTO>> GetListByLangOrTag(int langId, string tag)
        {
            return await GetAcademy(0, langId, tag).ToListAsync();
        }

        public async Task<AcademyODTO> EditAcademy(AcademyIDTO academyIDTO)
        {
            var academy = _mapper.Map<Academy>(academyIDTO);

            academy.UpdatedDate = DateTime.Now;

            _context.Entry(academy).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetAcademyById(academy.AcademyId);
        }

        public async Task<AcademyODTO> AddAcademy(AcademyIDTO academyIDTO)
        {
            var academy = _mapper.Map<Academy>(academyIDTO);
            academy.AcademyId = 0;
            academy.CreatedDate = DateTime.Now;
            academy.UpdatedDate = null;
            _context.Academies.Add(academy);

            await SaveContextChangesAsync();

            return await GetAcademyById(academy.AcademyId);
        }

        public async Task<AcademyODTO> DeleteAcademy(int id)
        {
            //TODO Videti sa frontom da li im treba brisanje u nazad
            //var pageArtical = await _context.PageArticles.Where(x => x.AcademyId == id).Select(x => x.AcademyId).ToListAsync();

            //if (pageArtical.Count != 0)
            //{
            //    foreach (var item in pageArtical)
            //    {
            //        var pageart = await _context.PageArticles.Where(x => x.AcademyId == item).FirstOrDefaultAsync();
            //        _context.PageArticles.Remove(pageart);
            //        await SaveContextChangesAsync();
            //    }
            //}

            var academy = await _context.Academies.FindAsync(id);
            if (academy == null) return null;

            var academyODTO = await GetAcademyById(id);
            _context.Academies.Remove(academy);
            await SaveContextChangesAsync();
            return academyODTO;
        }

        #endregion Academy

        #region PagesSettings

        private IQueryable<PagesSettingsODTO> GetPagesSettings(int id, int langId)
        {
            return from x in _context.PagesSettings
                   .Include(x => x.DataType)
                   .Include(x => x.Language)
                   .Include(x => x.Review)
                   .Include(x => x.Serp)
                   where (id == 0 || x.PagesSettingsId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<PagesSettingsODTO>(x);
        }

        public async Task<PagesSettingsODTO> GetPagesSettingsById(int id)
        {
            return await GetPagesSettings(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<PagesSettingsODTO> GetPagesSettingsByLangId(int langId)
        {
            return await GetPagesSettings(0, langId).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<PagesSettingsODTO> EditPagesSettings(PagesSettingsIDTO pagesSettingsIDTO)
        {
            var pagesSettings = _mapper.Map<PagesSettings>(pagesSettingsIDTO); ;

            _context.Entry(pagesSettings).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetPagesSettingsById(pagesSettings.PagesSettingsId);
        }

        public async Task<PagesSettingsODTO> AddPagesSettings(PagesSettingsIDTO pagesSettingsIDTO)
        {
            var pagesSettings = _mapper.Map<PagesSettings>(pagesSettingsIDTO);
            pagesSettings.PagesSettingsId = 0;
            _context.PagesSettings.Add(pagesSettings);

            await SaveContextChangesAsync();

            return await GetPagesSettingsById(pagesSettings.PagesSettingsId);
        }

        public async Task<PagesSettingsODTO> DeletePagesSettings(int id)
        {
            var pagesSetings = await _context.PagesSettings.FindAsync(id);
            if (pagesSetings == null) return null;

            var pagesSettingsODTO = await GetPagesSettingsById(id);
            _context.PagesSettings.Remove(pagesSetings);
            await SaveContextChangesAsync();
            return pagesSettingsODTO;
        }

        #endregion PagesSettings

        #region NewsFeed

        private IQueryable<NewsFeedODTO> GetNewsFeed(int id, int langId)
        {
            return from x in _context.NewsFeeds
                   .Include(x => x.Review)
                   .Include(x => x.Language)
                   .Include(x => x.UrlTable)
                   where (id == 0 || x.NewsFeedId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<NewsFeedODTO>(x);
        }

        public async Task<NewsFeedODTO> GetNewsFeedById(int id)
        {
            return await GetNewsFeed(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<GetNewsFeedListODTO>> GetListNewsFeedByLangId(int languageId)
        {
            var newsFeed = _context.NewsFeeds.Where(x => x.LanguageId == languageId).Select(x => new GetNewsFeedListODTO
            {
                Name = _context.Review.Where(e => e.ReviewId == x.ReviewId).Select(x => x.Name).FirstOrDefault(),
                NewsText = x.NewsText,
                CreatedDate = x.CreatedDate,
                NewsFeedId = x.NewsFeedId,
                Market = x.Market,
                TagLine = x.TagLine,
                UrlTableId = x.UrlTableId,
                URL = x.UrlTable.URL,
                RedFlag = x.RedFlag,
                //TODO DataType treba da bude 'review'
                Route = _context.Routes.Where(e => e.DataTypeId == 1 && e.ReviewId == x.ReviewId).Select(e => e.UrlTableId).FirstOrDefault(),
                Logo = _context.Review.Where(e => e.ReviewId == x.ReviewId).Select(e => e.Logo).FirstOrDefault()
            }).OrderBy(x => x.CreatedDate).ToListAsync();

            return await newsFeed;
        }

        public async Task<List<GetNewsFeedListODTO>> GetAllNews(int Id)
        {
            if (Id != null)
            {
                return await (from x in _context.NewsFeeds
                              select new GetNewsFeedListODTO
                              {
                                  //TODO DataType treba da bude 'review' i proveriti kakac where uslov treab da bude
                                  Route = _context.Routes.Where(e => e.DataTypeId == 1 && e.ReviewId == x.ReviewId).Select(e => e.UrlTableId).FirstOrDefault(),
                                  NewsText = x.NewsText,
                                  CreatedDate = x.CreatedDate,
                                  NewsFeedId = x.NewsFeedId,
                                  Name = _context.Review.Where(e => e.ReviewId == x.ReviewId).Select(x => x.Name).FirstOrDefault(),
                                  Market = x.Market,
                                  TagLine = x.TagLine,
                                  RedFlag = x.RedFlag,
                                  UrlTableId = x.UrlTableId,
                                  URL = x.UrlTable.URL,
                              }).OrderByDescending(x => x.CreatedDate).ToListAsync();
            }
            else
            {
                return await (from x in _context.NewsFeeds
                                  //TODO DataType treba da bude 'review' i proveriti kakac where uslov treab da bude
                              join r in _context.Routes.Where(e => e.DataTypeId == 1) on x.ReviewId equals r.ReviewId into c
                              from b in c.DefaultIfEmpty()
                              select new GetNewsFeedListODTO
                              {
                                  NewsText = x.NewsText,
                                  CreatedDate = x.CreatedDate,
                                  NewsFeedId = x.NewsFeedId,
                                  Name = x.Review.Name,
                                  Route = b.UrlTableId,
                                  Market = x.Market,
                                  TagLine = x.TagLine,
                                  RedFlag = x.RedFlag,
                                  UrlTableId = x.UrlTableId,
                                  URL = x.UrlTable.URL
                              }).OrderByDescending(x => x.CreatedDate).ToListAsync();
            }
        }

        public async Task<NewsFeedODTO> EditNewsFeed(NewsFeedIDTO newsFeedIDTO)
        {
            var newsFeeds = _mapper.Map<NewsFeed>(newsFeedIDTO); ;

            _context.Entry(newsFeeds).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetNewsFeedById(newsFeeds.NewsFeedId);
        }

        public async Task<NewsFeedODTO> AddNewsFeed(NewsFeedIDTO newsFeedIDTO)
        {
            var newsFeeds = _mapper.Map<NewsFeed>(newsFeedIDTO);
            newsFeeds.NewsFeedId = 0;
            _context.NewsFeeds.Add(newsFeeds);

            await SaveContextChangesAsync();

            return await GetNewsFeedById(newsFeeds.NewsFeedId);
        }

        public async Task<NewsFeedODTO> DeleteNewsFeed(int id)
        {
            var newsFeeds = await _context.NewsFeeds.FindAsync(id);
            if (newsFeeds == null) return null;

            var newsFeedODTO = await GetNewsFeedById(id);
            _context.NewsFeeds.Remove(newsFeeds);
            await SaveContextChangesAsync();
            return newsFeedODTO;
        }

        #endregion NewsFeed

        #region PageArticles

        private IQueryable<PageArticlesODTO> GetPageArticles(int id)
        {
            return from x in _context.PageArticles
                   .Include(x => x.Academy)
                   .Include(x => x.Page)
                   where (id == 0 || x.PageArticleId == id)
                   select _mapper.Map<PageArticlesODTO>(x);
        }

        public async Task<PageArticlesODTO> GetPageArticlesById(int id)
        {
            return await GetPageArticles(id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<PageArticlesODTO> EditPageArticles(PagesArticlesIDTO pageArticlesIDTO)
        {
            var pageArticles = _mapper.Map<PageArticles>(pageArticlesIDTO);

            _context.Entry(pageArticles).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetPageArticlesById(pageArticles.PageArticleId);
        }

        public async Task<PageArticlesODTO> AddPageArticles(PagesArticlesIDTO pageArticlesIDTO)
        {
            var pageArticles = _mapper.Map<PageArticles>(pageArticlesIDTO);
            pageArticles.PageArticleId = 0;
            _context.PageArticles.Add(pageArticles);

            await SaveContextChangesAsync();

            return await GetPageArticlesById(pageArticles.PageArticleId);
        }

        public async Task<PageArticlesODTO> DeletePageArticles(int id)
        {
            var pageArticles = await _context.PageArticles.FindAsync(id);
            if (pageArticles == null) return null;

            var pageArticlesODTO = await GetPageArticlesById(id);
            _context.PageArticles.Remove(pageArticles);
            await SaveContextChangesAsync();
            return pageArticlesODTO;
        }

        #endregion PageArticles

        #region HomeSettings

        private IQueryable<HomeSettings> GetHomeSettings(int id, int langId)
        {
            return from x in _context.HomeSettings
                   where (id == 0 || x.HomeSettingsId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select x;
        }

        public async Task<HomeSettingsODTO> GetHomeSettingsById(int id)
        {
            return await _mapper.ProjectTo<HomeSettingsODTO>(GetHomeSettings(id, 0)).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<HomeSettingsODTO>> GetHomeSettingsByLangId(int langId)
        {
            return await _mapper.ProjectTo<HomeSettingsODTO>(GetHomeSettings(0, langId)).ToListAsync();
        }

        public async Task<HomeSettingsODTO> EditHomeSettings(HomeSettingsIDTO homeSettingsIDTO)
        {
            var homeSettings = _mapper.Map<HomeSettings>(homeSettingsIDTO);

            _context.Entry(homeSettings).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetHomeSettingsById(homeSettings.HomeSettingsId);
        }

        public async Task<HomeSettingsODTO> AddHomeSettings(HomeSettingsIDTO homeSettingsIDTO)
        {
            var homeSettings = _mapper.Map<HomeSettings>(homeSettingsIDTO);

            homeSettings.HomeSettingsId = 0;

            _context.HomeSettings.Add(homeSettings);

            await SaveContextChangesAsync();

            return await GetHomeSettingsById(homeSettings.HomeSettingsId);
        }

        public async Task<HomeSettingsODTO> DeleteHomeSettings(int id)
        {
            var homeSettings = await _context.HomeSettings.FindAsync(id);
            if (homeSettings == null) return null;

            var homeSettingsODTO = await GetHomeSettingsById(id);
            _context.HomeSettings.Remove(homeSettings);
            await SaveContextChangesAsync();
            return homeSettingsODTO;
        }

        #endregion HomeSettings

        #region AboutSettings

        private IQueryable<AboutSettings> GetAboutSettings(int id, int langId)
        {
            return from x in _context.AboutSettings
                   where (id == 0 || x.AboutSettingsId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select x;
        }

        public async Task<AboutSettingsODTO> GetAboutSettingsById(int id)
        {
            return await _mapper.ProjectTo<AboutSettingsODTO>(GetAboutSettings(id, 0)).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<AboutSettingsODTO>> GetAboutSettingsByLangId(int langId)
        {
            return await _mapper.ProjectTo<AboutSettingsODTO>(GetAboutSettings(0, langId)).ToListAsync();
        }

        public async Task<AboutSettingsODTO> EditAboutSettings(AboutSettingsIDTO aboutSettingsIDTO)
        {
            var aboutSettings = _mapper.Map<AboutSettings>(aboutSettingsIDTO);
            _context.Entry(aboutSettings).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetAboutSettingsById(aboutSettings.AboutSettingsId);
        }

        public async Task<AboutSettingsODTO> AddAboutSettings(AboutSettingsIDTO aboutSettingsIDTO)
        {
            var aboutSettings = _mapper.Map<AboutSettings>(aboutSettingsIDTO);

            aboutSettings.AboutSettingsId = 0;

            _context.AboutSettings.Add(aboutSettings);

            await SaveContextChangesAsync();

            return await GetAboutSettingsById(aboutSettings.AboutSettingsId);
        }

        public async Task<AboutSettingsODTO> DeleteAboutSettings(int id)
        {
            var aboutSettings = await _context.AboutSettings.FindAsync(id);
            if (aboutSettings == null) return null;

            var aboutSettingsODTO = await GetAboutSettingsById(id);
            _context.AboutSettings.Remove(aboutSettings);
            await SaveContextChangesAsync();
            return aboutSettingsODTO;
        }

        #endregion AboutSettings

        #region SettingsAttribute

        private IQueryable<SettingsAttribute> GetSettingsAttribute(int id, int langId, int datatypeId)
        {
            return from x in _context.SettingsAttributes
                   where (id == 0 || x.SettingsAttributeId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   && (datatypeId == 0 || x.DataTypeId == datatypeId)
                   select x;
        }

        public async Task<SettingsAttributeODTO> GetSettingsAttributeById(int id)
        {
            return await _mapper.ProjectTo<SettingsAttributeODTO>(GetSettingsAttribute(id, 0, 0)).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<SettingsAttributeODTO>> GetSettingsAttributeByLangId(int langId)
        {
            return await _mapper.ProjectTo<SettingsAttributeODTO>(GetSettingsAttribute(0, langId, 0)).ToListAsync();
        }

        public async Task<List<SettingsAttributeODTO>> GetSettingsAttributeByDataTypeId(int datatypeId)
        {
            return await _mapper.ProjectTo<SettingsAttributeODTO>(GetSettingsAttribute(0, 0, datatypeId)).ToListAsync();
        }

        public async Task<SettingsAttributeODTO> EditSettingsAttribute(SettingsAttributeIDTO settingsAttributeIDTO)
        {
            var settingsAttribute = _mapper.Map<SettingsAttribute>(settingsAttributeIDTO);
            _context.Entry(settingsAttribute).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetSettingsAttributeById(settingsAttribute.SettingsAttributeId);
        }

        public async Task<SettingsAttributeODTO> AddSettingsAttribute(SettingsAttributeIDTO settingsAttributeIDTO)
        {
            var settingsAttribute = _mapper.Map<SettingsAttribute>(settingsAttributeIDTO);

            settingsAttribute.SettingsAttributeId = 0;

            _context.SettingsAttributes.Add(settingsAttribute);

            await SaveContextChangesAsync();

            return await GetSettingsAttributeById(settingsAttribute.SettingsAttributeId);
        }

        public async Task<SettingsAttributeODTO> DeleteSettingsAttribute(int id)
        {
            var settingsAttribute = await _context.SettingsAttributes.FindAsync(id);
            if (settingsAttribute == null) return null;

            var settingsAttributeODTO = await GetSettingsAttributeById(id);
            _context.SettingsAttributes.Remove(settingsAttribute);
            await SaveContextChangesAsync();
            return settingsAttributeODTO;
        }

        #endregion SettingsAttribute
    }
}