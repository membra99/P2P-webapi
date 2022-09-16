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
                   && (x.LanguageId == langId)
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

        //TODO GetDropdownValues, GetDropdownValuesLocale

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
                          where (pageId == 0 || x.ReviewId == pageId)
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
                   where (id == 0 || x.PageId == id)
                   && (languageId == 0 && x.LanguageId == languageId)
                   && (dataTypeId == 0 && x.DataTypeId == languageId)
                   select _mapper.Map<PageODTO>(x);
        }

        public async Task<PageODTO> GetPageById(int id)
        {
            return await GetPage(id, 0, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        //TODO KADA SE ZAVRSI AKADEMIJA
        //public async Task<GetPageODTO> GetItem(int id)
        //{
        //    List<ReviewContentDropdownODTO> reviews = await ListOfReviews();
        //    var page = await _context.Pages.FirstOrDefaultAsync(e => e.PageId == id);
        //    var popularArticles = _context..Select(e => new
        //    {
        //        value = e.AcademyID,
        //        label = e.title,

        //    }).ToList();

        //    var retVal = new GetPageODTO
        //    {
        //         PageId = page.PageId,
        //        Page_Title = page.PageTitle,
        //        SerpId = page.SerpId,
        //        DataTypeId = page.DataTypeId,
        //        ReviewContentDropdowns = reviews,
        //        ReviewId = (int)page.ReviewId,
        //        PopularArticles = popularArticles,
        //        SelectedPopularArticles = _context.tbl_Page_Articles.Where(e => e.PageId == page.id).Select(e => e.AcademyId).ToList(),
        //    };

        //    return retVal;
        //}

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

        public async Task<GetPageODTO> GetItemContent(int? id, int urlId, int langId)
        {
            try
            {
                if (id != null)
                {
                    var page = _context.Pages.FirstOrDefault(e => e.PageId == id);

                    var retVal = new GetPageODTO
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
                    var retVal = new GetPageODTO
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
            //TODO Kada bude PageAtrical i academy prepraviti brisanje
            //var pageArtical = await _context.PageArticles.Where(x => x.PageId == id).Select(x => x.Id).ToListAsync();

            //foreach (var item in pageArtical)
            //{
            //    var pageart = await _context.PagesArtical.FindAsync(item.PageId);
            //    _context.PagesArtic.Remove(pageart);

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

        private IQueryable<ReviewODTO> GetReview(int id)
        {
            return from x in _context.Review
                   where (id == 0 || x.ReviewId == id)
                   select _mapper.Map<ReviewODTO>(x);
        }

        public async Task<ReviewODTO> GetReviewById(int id)
        {
            return await GetReview(id).AsNoTracking().SingleOrDefaultAsync();
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
    }
}