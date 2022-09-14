using AutoMapper;
using Entities.Context;
using Entities.P2P;
using Entities.P2P.MainData;
using Entities.P2P.MainData.Settings;
using Microsoft.EntityFrameworkCore;
using P2P.Base.Services;
using P2P.DTO.Input;
using P2P.DTO.Output;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P2P.Services
{
    public class MainDataServices : BaseService
    {
        public MainDataServices(MainContext context, IMapper mapper) : base(context, mapper)
        {
        }

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
            if (id != 0)
            {
                return await GetTestimonial(id, null, 0).AsNoTracking().ToListAsync();
            }
            else
            {
                return await GetTestimonial(0, null, 0).AsNoTracking().ToListAsync();
            }
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

        public async Task<NavigationSettingsODTO> EditnavigationSettings(NavigationSettingsIDTO navigationSettingsIDTO)
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
        private IQueryable<FooterSettingsODTO> GetFooterSettings(int id, int langId)
        {
            return from x in _context.FooterSettings
                   where (id == 0 || x.FooterSettingsId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<FooterSettingsODTO>(x);
        }

        public async Task<FooterSettingsODTO> GetFooterSettingsById(int id)
        {
            return await GetFooterSettings(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<FooterSettingsODTO>> GetFooterSettingsByLangId(int langId)
        {
            return await GetFooterSettings(0, langId).ToListAsync();
        }

        public async Task<FooterSettingsODTO> EditFooterSettings(FooterSettingsIDTO footerSettingsIDTO)
        {
            var footerSettings = _mapper.Map<FooterSettings>(footerSettingsIDTO);
            footerSettings.FooterSettingsId = 0;
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

        #endregion

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

        #region Links

        private IQueryable<LinkODTO> GetLinks(int id)
        {
            return from x in _context.Links
                   where (id == 0 || x.LinkId == id)
                   select _mapper.Map<LinkODTO>(x);
        }

        public async Task<LinkODTO> GetLinkById(int id)
        {
            return await GetLinks(id).AsNoTracking().SingleOrDefaultAsync();
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
    }
}