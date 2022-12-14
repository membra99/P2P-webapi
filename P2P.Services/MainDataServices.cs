using AutoMapper;
using Entities.Context;
using Entities.P2P.MainData;
using Entities.P2P.MainData.Settings;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Index.HPRtree;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P2P.Base.Services;
using P2P.DTO.Input;
using P2P.DTO.Input.EndpointIDTO;
using P2P.DTO.Output;
using P2P.DTO.Output.EndPointODTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataType = Entities.P2P.MainData.DataType;
using Language = Entities.P2P.MainData.Language;

namespace P2P.Services
{
    public class MainDataServices : BaseService
    {
        public MainDataServices(MainContext context, IMapper mapper) : base(context, mapper)
        {
        }

        #region ChangeDateFormatAdmin

        public async Task<YearMonthODTO> ChangeDateFormatAdmin(string serpTitle, string serpDescription, string Subtitle, string PageTitle, string Content, string Title)// Database [2022][December] => Admin[year][month]
        {
            YearMonthODTO YearMonth = new YearMonthODTO();
            if (serpTitle != null)
            {
                var YearForChange = Regex.Match(serpTitle, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChange != "")
                {
                    serpTitle = serpTitle.Replace(YearForChange, "[year]");
                }
                // set review.serp.serptitle [month] from [December] to December
                var MonthForChange = Regex.Match(serpTitle, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChange != "")
                {
                    serpTitle = serpTitle.Replace(MonthForChange, "[month]");
                }

                YearMonth.SerpTitle = serpTitle;
            }

            if (serpDescription != null)
            {
                var YearForChange = Regex.Match(serpDescription, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChange != "")
                {
                    serpDescription = serpDescription.Replace(YearForChange, "[year]");
                }
                // set review.serp.serptitle [month] from [December] to December
                var MonthForChange = Regex.Match(serpDescription, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChange != "")
                {
                    serpDescription = serpDescription.Replace(MonthForChange, "[month]");
                }
                YearMonth.SerpDescription = serpDescription;
            }

            if (PageTitle != null)
            {
                var YearForChange = Regex.Match(PageTitle, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChange != "")
                {
                    PageTitle = PageTitle.Replace(YearForChange, "[year]");
                }
                // set review.serp.serptitle [month] from [December] to December
                var MonthForChange = Regex.Match(PageTitle, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChange != "")
                {
                    PageTitle = PageTitle.Replace(MonthForChange, "[month]");
                }

                YearMonth.PageTitle = PageTitle;
            }

            if (Subtitle != null)
            {
                var YearForChange = Regex.Match(Subtitle, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChange != "")
                {
                    Subtitle = Subtitle.Replace(YearForChange, "[year]");
                }
                // set review.serp.serptitle [month] from [December] to December
                var MonthForChange = Regex.Match(Subtitle, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChange != "")
                {
                    Subtitle = Subtitle.Replace(MonthForChange, "[month]");
                }
                YearMonth.Subtitle = Subtitle;
            }

            if (Content != null)
            {
                var YearForChange = Regex.Match(Content, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChange != "")
                {
                    Content = Content.Replace(YearForChange, "[year]");
                }
                // set review.serp.serptitle [month] from [December] to December
                var MonthForChange = Regex.Match(Content, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChange != "")
                {
                    Content = Content.Replace(MonthForChange, "[month]");
                }
                YearMonth.Content = Content;
            }

            if (Title != null)
            {
                var YearForChange = Regex.Match(Title, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChange != "")
                {
                    Title = Title.Replace(YearForChange, "[year]");
                }
                // set review.serp.serptitle [month] from [December] to December
                var MonthForChange = Regex.Match(Title, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChange != "")
                {
                    Title = Title.Replace(MonthForChange, "[month]");
                }
                YearMonth.Title = Title;
            }

            return YearMonth;
        }

        #endregion ChangeDateFormatAdmin

        #region ChageDataFormatFront

        public async Task<YearMonthODTO> ChangeDateFormatFront(string serpTitle, string serpDescription, string Subtitle, string PageTitle, string Content, string Title, int? LangId)// Database [2022][December] => Front 2022, December
        {
            YearMonthODTO YearMonth = new YearMonthODTO();
            //SERPTITLE
            if (serpTitle != null)
            {
                var YearForChangeSerpTitle = Regex.Match(serpTitle, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChangeSerpTitle != "")
                {
                    YearForChangeSerpTitle = YearForChangeSerpTitle.Replace("[", string.Empty).Replace("]", string.Empty);
                    serpTitle = serpTitle.Replace("[" + DateTime.Now.Year + "]", YearForChangeSerpTitle);
                }

                var MonthForChangeSerpTitle = Regex.Match(serpTitle, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();

                if (MonthForChangeSerpTitle != "")
                {
                    switch (LangId)
                    {
                        case 1:
                            MonthForChangeSerpTitle = MonthForChangeSerpTitle.Replace("[", string.Empty).Replace("]", string.Empty);
                            break;

                        case 2:
                            MonthForChangeSerpTitle = MonthForChangeSerpTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE")));
                            break;

                        case 3:
                            MonthForChangeSerpTitle = MonthForChangeSerpTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("es-ES")));
                            break;

                        case 4:
                            MonthForChangeSerpTitle = MonthForChangeSerpTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("fr-FR")));
                            break;
                    }
                    serpTitle = serpTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", MonthForChangeSerpTitle);
                }
                YearMonth.SerpTitle = serpTitle;
            }
            //SERPDESCRIPTION
            if (serpDescription != null)
            {
                var YearForChangeDesc = Regex.Match(serpDescription, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChangeDesc != "")
                {
                    YearForChangeDesc = YearForChangeDesc.Replace("[", string.Empty).Replace("]", string.Empty);
                    serpDescription = serpDescription.Replace("[" + DateTime.Now.Year + "]", YearForChangeDesc);
                }

                var MonthForChangeDesc = Regex.Match(serpDescription, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChangeDesc != "")
                {
                    switch (LangId)
                    {
                        case 1:
                            MonthForChangeDesc = MonthForChangeDesc.Replace("[", string.Empty).Replace("]", string.Empty);
                            break;

                        case 2:
                            MonthForChangeDesc = MonthForChangeDesc.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE")));
                            break;

                        case 3:
                            MonthForChangeDesc = MonthForChangeDesc.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("ES-es")));
                            break;

                        case 4:
                            MonthForChangeDesc = MonthForChangeDesc.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("fr-FR")));
                            break;
                    }
                    serpDescription = serpDescription.Replace("[" + DateTime.Now.ToString("MMMM") + "]", MonthForChangeDesc);
                }
                YearMonth.SerpDescription = serpDescription;
            }
            //SUBTITLE
            if (Subtitle != null)
            {
                var YearForChangeSubtitle = Regex.Match(Subtitle, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChangeSubtitle != "")
                {
                    YearForChangeSubtitle = YearForChangeSubtitle.Replace("[", string.Empty).Replace("]", string.Empty);
                    Subtitle = Subtitle.Replace("[" + DateTime.Now.Year + "]", YearForChangeSubtitle);
                }

                var MonthForChangeSubtitle = Regex.Match(Subtitle, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChangeSubtitle != "")
                {
                    switch (LangId)
                    {
                        case 1:
                            MonthForChangeSubtitle = MonthForChangeSubtitle.Replace("[", string.Empty).Replace("]", string.Empty);
                            break;

                        case 2:
                            MonthForChangeSubtitle = MonthForChangeSubtitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE")));
                            break;

                        case 3:
                            MonthForChangeSubtitle = MonthForChangeSubtitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("ES-es")));
                            break;

                        case 4:
                            MonthForChangeSubtitle = MonthForChangeSubtitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("fr-FR")));
                            break;
                    }
                    Subtitle = Subtitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", MonthForChangeSubtitle);
                }

                YearMonth.Subtitle = Subtitle;
            }
            //PAGE TITLE
            if (PageTitle != null)
            {
                var YearForChangePageTitle = Regex.Match(PageTitle, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChangePageTitle != "")
                {
                    YearForChangePageTitle = YearForChangePageTitle.Replace("[", string.Empty).Replace("]", string.Empty);
                    PageTitle = PageTitle.Replace("[" + DateTime.Now.Year + "]", YearForChangePageTitle);
                }

                var MonthForChangePageTitle = Regex.Match(PageTitle, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChangePageTitle != "")
                {
                    switch (LangId)
                    {
                        case 1:
                            MonthForChangePageTitle = MonthForChangePageTitle.Replace("[", string.Empty).Replace("]", string.Empty);
                            break;

                        case 2:
                            MonthForChangePageTitle = MonthForChangePageTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE")));
                            break;

                        case 3:
                            MonthForChangePageTitle = MonthForChangePageTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("ES-es")));
                            break;

                        case 4:
                            MonthForChangePageTitle = MonthForChangePageTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("fr-FR")));
                            break;
                    }
                    PageTitle = PageTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", MonthForChangePageTitle);
                }

                YearMonth.PageTitle = PageTitle;
            }
            //CONTENT
            if (Content != null)
            {
                var YearForChangeContent = Regex.Match(Content, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChangeContent != "")
                {
                    YearForChangeContent = YearForChangeContent.Replace("[", string.Empty).Replace("]", string.Empty);
                    Content = Content.Replace("[" + DateTime.Now.Year + "]", YearForChangeContent);
                }

                var MonthForChangeContent = Regex.Match(Content, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChangeContent != "")
                {
                    switch (LangId)
                    {
                        case 1:
                            MonthForChangeContent = MonthForChangeContent.Replace("[", string.Empty).Replace("]", string.Empty);
                            break;

                        case 2:
                            MonthForChangeContent = MonthForChangeContent.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE")));
                            break;

                        case 3:
                            MonthForChangeContent = MonthForChangeContent.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("ES-es")));
                            break;

                        case 4:
                            MonthForChangeContent = MonthForChangeContent.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("fr-FR")));
                            break;
                    }
                    Content = Content.Replace("[" + DateTime.Now.ToString("MMMM") + "]", MonthForChangeContent);
                }

                YearMonth.Content = Content;
            }
            //TITLE
            if (Title != null)
            {
                var YearForChangeTitle = Regex.Match(Title, @"\[" + DateTime.Now.Year + "]").ToString();
                if (YearForChangeTitle != "")
                {
                    YearForChangeTitle = YearForChangeTitle.Replace("[", string.Empty).Replace("]", string.Empty);
                    Title = Title.Replace("[" + DateTime.Now.Year + "]", YearForChangeTitle);
                }

                var MonthForChangeTitle = Regex.Match(Title, @"\[" + DateTime.Now.ToString("MMMM") + "]").ToString();
                if (MonthForChangeTitle != "")
                {
                    switch (LangId)
                    {
                        case 1:
                            MonthForChangeTitle = MonthForChangeTitle.Replace("[", string.Empty).Replace("]", string.Empty);
                            break;

                        case 2:
                            MonthForChangeTitle = MonthForChangeTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE")));
                            break;

                        case 3:
                            MonthForChangeTitle = MonthForChangeTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("ES-es")));
                            break;

                        case 4:
                            MonthForChangeTitle = MonthForChangeTitle.Replace("[" + DateTime.Now.ToString("MMMM") + "]", DateTime.Now.ToString("MMMM", CultureInfo.GetCultureInfo("fr-FR")));
                            break;
                    }
                    Title = Title.Replace("[" + DateTime.Now.ToString("MMMM") + "]", MonthForChangeTitle);
                }
                YearMonth.Title = Title;
            }
            return YearMonth;
        }

        #endregion ChageDataFormatFront

        #region EditDate

        public async Task<YearMonthODTO> EditDate(string serpTitle, string serpDescription, string Subtitle, string PageTitle, string Content, string Title)//[year] [month]=> [2022] [December]
        {
            YearMonthODTO YearMonth = new YearMonthODTO();
            //SERPTITLE
            if (serpTitle != null)
            {
                if (serpTitle.Contains("[year]"))
                {
                    serpTitle = serpTitle.Replace("[year]", "[" + (DateTime.Now.Year).ToString() + "]");
                }
                if (serpTitle.Contains("[month]"))
                {
                    serpTitle = serpTitle.Replace("[month]", "[" + DateTime.Now.ToString("MMMM") + "]");
                }
                YearMonth.SerpTitle = serpTitle;
            }
            //serpDescription
            if (serpDescription != null)
            {
                if (serpDescription.Contains("[year]"))
                {
                    serpDescription = serpDescription.Replace("[year]", "[" + (DateTime.Now.Year).ToString() + "]");
                }
                if (serpDescription.Contains("[month]"))
                {
                    serpDescription = serpDescription.Replace("[month]", "[" + DateTime.Now.ToString("MMMM") + "]");
                }
                YearMonth.SerpDescription = serpDescription;
            }
            //Subtitle
            if (Subtitle != null)
            {
                if (Subtitle.Contains("[year]"))
                {
                    Subtitle = Subtitle.Replace("[year]", "[" + (DateTime.Now.Year).ToString() + "]");
                }
                if (Subtitle.Contains("[month]"))
                {
                    Subtitle = Subtitle.Replace("[month]", "[" + DateTime.Now.ToString("MMMM") + "]");
                }
                YearMonth.Subtitle = Subtitle;
            }
            //PageTitle
            if (PageTitle != null)
            {
                if (PageTitle.Contains("[year]"))
                {
                    PageTitle = PageTitle.Replace("[year]", "[" + (DateTime.Now.Year).ToString() + "]");
                }
                if (PageTitle.Contains("[month]"))
                {
                    PageTitle = PageTitle.Replace("[month]", "[" + DateTime.Now.ToString("MMMM") + "]");
                }
                YearMonth.PageTitle = PageTitle;
            }
            //Content
            if (Content != null)
            {
                if (Content.Contains("[year]"))
                {
                    Content = Content.Replace("[year]", "[" + (DateTime.Now.Year).ToString() + "]");
                }
                if (Content.Contains("[month]"))
                {
                    Content = Content.Replace("[month]", "[" + DateTime.Now.ToString("MMMM") + "]");
                }
                YearMonth.Content = Content;
            }
            //Title
            if (Title != null)
            {
                if (Title.Contains("[year]"))
                {
                    Title = Title.Replace("[year]", "[" + (DateTime.Now.Year).ToString() + "]");
                }
                if (Title.Contains("[month]"))
                {
                    Title = Title.Replace("[month]", "[" + DateTime.Now.ToString("MMMM") + "]");
                }
                YearMonth.Title = Title;
            }
            return YearMonth;
        }

        #endregion EditDate

        #region UpdateSerpYearAndMonthLogic

        public async Task<YearMonthODTO> UpdateSerpYearAndMonthLogic(string serpTitle, string serpDescription, string Subtitle, string PageTitle, string Content, string Title)
        {
            var CurrentMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            var MonthForChange = CurrentMonth.Replace("January", DateTime.Now.AddMonths(-1).ToString("MMMM"));

            YearMonthODTO YearMonth = new YearMonthODTO();
            if (serpTitle != null)
            {
                var YearForChangeSerpTitle = Regex.Match(serpTitle, @"\[" + (DateTime.Now.Year - 1) + "]").ToString();
                if (YearForChangeSerpTitle != "")
                {
                    YearForChangeSerpTitle = ("[" + DateTime.Now.Year + "]").ToString();
                    serpTitle = serpTitle.Replace("[" + (DateTime.Now.Year - 1) + "]", YearForChangeSerpTitle);
                }

                var MonthForChangeSerpTitle = Regex.Match(serpTitle, @"\[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]").ToString();
                if (MonthForChangeSerpTitle != "")
                {
                    MonthForChangeSerpTitle = "[" + DateTime.Now.ToString("MMMM") + "]";
                    serpTitle = serpTitle.Replace("[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]", MonthForChangeSerpTitle);
                }
                YearMonth.SerpTitle = serpTitle;
            }

            if (serpDescription != null)
            {
                var YearForChangeserpDescription = Regex.Match(serpDescription, @"\[" + (DateTime.Now.Year - 1) + "]").ToString();
                if (YearForChangeserpDescription != "")
                {
                    YearForChangeserpDescription = ("[" + DateTime.Now.Year + "]").ToString();
                    serpDescription = serpDescription.Replace("[" + (DateTime.Now.Year - 1) + "]", YearForChangeserpDescription);
                }

                var MonthForChangeserpDescription = Regex.Match(serpDescription, @"\[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]").ToString();
                if (MonthForChangeserpDescription != "")
                {
                    MonthForChangeserpDescription = "[" + DateTime.Now.ToString("MMMM") + "]";
                    serpDescription = serpDescription.Replace("[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]", MonthForChangeserpDescription);
                }
                YearMonth.SerpDescription = serpDescription;
            }

            if (Subtitle != null)
            {
                var YearForChangeSubtitle = Regex.Match(Subtitle, @"\[" + (DateTime.Now.Year - 1) + "]").ToString();
                if (YearForChangeSubtitle != "")
                {
                    YearForChangeSubtitle = ("[" + DateTime.Now.Year + "]").ToString();
                    Subtitle = Subtitle.Replace("[" + (DateTime.Now.Year - 1) + "]", YearForChangeSubtitle);
                }

                var MonthForChangeSubtitle = Regex.Match(Subtitle, @"\[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]").ToString();
                if (MonthForChangeSubtitle != "")
                {
                    MonthForChangeSubtitle = "[" + DateTime.Now.ToString("MMMM") + "]";
                    Subtitle = Subtitle.Replace("[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]", MonthForChangeSubtitle);
                }
                YearMonth.Subtitle = Subtitle;
            }

            if (PageTitle != null)
            {
                var YearForChangePageTitle = Regex.Match(PageTitle, @"\[" + (DateTime.Now.Year - 1) + "]").ToString();
                if (YearForChangePageTitle != "")
                {
                    YearForChangePageTitle = ("[" + DateTime.Now.Year + "]").ToString();
                    PageTitle = PageTitle.Replace("[" + (DateTime.Now.Year - 1) + "]", YearForChangePageTitle);
                }

                var MonthForChangePageTitle = Regex.Match(PageTitle, @"\[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]").ToString();
                if (MonthForChangePageTitle != "")
                {
                    MonthForChangePageTitle = "[" + DateTime.Now.ToString("MMMM") + "]";
                    PageTitle = PageTitle.Replace("[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]", MonthForChangePageTitle);
                }
                YearMonth.PageTitle = PageTitle;
            }

            if (Content != null)
            {
                var YearForChangeContent = Regex.Match(Content, @"\[" + (DateTime.Now.Year - 1) + "]").ToString();
                if (YearForChangeContent != "")
                {
                    YearForChangeContent = ("[" + DateTime.Now.Year + "]").ToString();
                    Content = Content.Replace("[" + (DateTime.Now.Year - 1) + "]", YearForChangeContent);
                }

                var MonthForChangeContent = Regex.Match(Content, @"\[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]").ToString();
                if (MonthForChangeContent != "")
                {
                    MonthForChangeContent = "[" + DateTime.Now.ToString("MMMM") + "]";
                    Content = Content.Replace("[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]", MonthForChangeContent);
                }
                YearMonth.Content = Content;
            }

            if (Title != null)
            {
                var YearForChangeTitle = Regex.Match(Title, @"\[" + ((DateTime.Now.Year) - 1) + "]").ToString();
                if (YearForChangeTitle != "")
                {
                    YearForChangeTitle = ("[" + DateTime.Now.Year + "]").ToString();
                    Title = Title.Replace("[" + ((DateTime.Now.Year) - 1) + "]", YearForChangeTitle);
                }

                var MonthForChangeTitle = Regex.Match(Title, @"\[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]").ToString();
                if (MonthForChangeTitle != "")
                {
                    MonthForChangeTitle = "[" + DateTime.Now.ToString("MMMM") + "]";
                    Title = Title.Replace("[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]", MonthForChangeTitle);
                }
                YearMonth.Title = Title;
            }

            return YearMonth;
        }

        #endregion UpdateSerpYearAndMonthLogic

        #region UpdateYearMonthFormat

        public async Task UpdateSerpYearAndMonth()// Database [2022][December] => [2023] [January]
        {
            var LastMonth = "[" + DateTime.Now.AddMonths(-1).ToString("MMMM") + "]";
            var LastYear = ("[" + ((DateTime.Now.Year) - 1) + "]").ToString();
            YearMonthODTO ym;
            var Academy = await _context.Academies.Where(x => (x.Title.Contains(LastMonth)) || (x.Title.Contains(LastYear))).ToListAsync();
            if (Academy.Count != 0)
            {
                foreach (var item in Academy)
                {
                    ym = await UpdateSerpYearAndMonthLogic(null, null, null, null, null, item.Title);
                    item.Title = ym.Title;
                    _context.Entry(item).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
            }

            var Serps = await _context.Serps.Where(x => (x.SerpTitle.Contains(LastYear)) || (x.SerpTitle.Contains(LastMonth)) || (x.SerpDescription.Contains(LastYear)) || (x.SerpDescription.Contains(LastMonth)) || (x.Subtitle.Contains(LastYear)) || (x.Subtitle.Contains(LastMonth))).ToListAsync();

            if (Serps.Count != 0)
            {
                foreach (var item in Serps)
                {
                    ym = await UpdateSerpYearAndMonthLogic(item.SerpTitle, item.SerpDescription, item.Subtitle, null, null, null);
                    item.SerpTitle = ym.SerpTitle;
                    item.SerpDescription = ym.SerpDescription;
                    item.Subtitle = ym.Subtitle;
                    _context.Entry(item).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
            }

            var Pages = await _context.Pages.Where(x => (x.PageTitle.Contains(LastYear)) || (x.PageTitle.Contains(LastMonth)) || (x.Content.Contains(LastYear)) || (x.Content.Contains(LastMonth))).ToListAsync();
            if (Pages.Count != 0)
            {
                foreach (var item in Pages)
                {
                    ym = await UpdateSerpYearAndMonthLogic(null, null, null, item.PageTitle, item.Content, null);
                    item.PageTitle = ym.PageTitle;
                    item.Content = ym.Content;
                    _context.Entry(item).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
            }

            var Blogs = await _context.Blogs.Where(x => (x.PageTitle.Contains(LastYear)) || (x.PageTitle.Contains(LastMonth)) || (x.Content.Contains(LastYear)) || (x.Content.Contains(LastMonth))).ToListAsync();
            if (Blogs.Count != 0)
            {
                foreach (var item in Blogs)
                {
                    ym = await UpdateSerpYearAndMonthLogic(null, null, null, item.PageTitle, item.Content, null);
                    item.PageTitle = ym.PageTitle;
                    item.Content = ym.Content;
                    _context.Entry(item).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
            }

            var Reviews = await _context.Review.Where(x => (x.ReviewContent.Contains(LastYear)) || (x.ReviewContent.Contains(LastMonth))).ToListAsync();
            if (Reviews.Count != 0)
            {
                foreach (var item in Reviews)
                {
                    ym = await UpdateSerpYearAndMonthLogic(null, null, null, null, item.ReviewContent, null);
                    item.ReviewContent = ym.Content;
                    _context.Entry(item).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
            }
        }

        #endregion UpdateYearMonthFormat

        #region GlobalFunctions & Statics

        public const int REVIEW_TYPEID = 1;
        public const int ACADEMY_TYPEID = 2;
        public const int CASHBACK_TYPEID = 3;
        public const int FAQLIST_TYPEID = 4;
        public const int FAQTITLES_TYPEID = 5;
        public const int LINKS_TYPEID = 6;
        public const int NEWS_FEED_TYPEID = 7;
        public const int PAGE_ARTICLES_TYPEID = 8;
        public const int PAGES_TYPEID = 9;
        public const int ROUTES_TYPEID = 10;
        public const int SERPS_TYPEID = 11;
        public const int URL_TABLES_TYPEID = 12;
        public const int FOOTER_SETTINGS_TYPEID = 13;
        public const int HOME_SETTINGS_TYPEID = 14;
        public const int ABOUT_SETTINGS_TYPEID = 15;
        public const int GENERAL_TYPEID = 16;
        public const int CASHBACK_BONUS_TYPEID = 17;
        public const int ABOUT_TYPEID = 18;
        public const int NEWS_SETTINGS_TYPEID = 19;
        public const int BONUS_SETTINGS_TYPEID = 20;
        public const int ACADEMY_SETTINGS_TYPEID = 21;
        public const int REVIEW_SETTINGS_TYPEID = 22;
        public const int MENU_ACADEMY_TYPEID = 23;
        public const int MENU_HOME_TYPEID = 24;
        public const int MENU_NEWS_TYPEID = 25;
        public const int MENU_REVIEW_TYPEID = 26;
        public const int NAVIGATION_SETTINGS_TYPEID = 27;
        public const int HIGHLIGHT_ATTR_TYPEID = 28;
        public const int BENEFIT_ATTR_TYPEID = 29;
        public const int DISSADVANTAGE_ATTR_TYPEID = 30;
        public const int A_ITEM_ANCHOR_TYPEID = 31;
        public const int P_ITEM_ANCHOR_TYPEID = 32;
        public const int A_ITEM_LINK_TYPEID = 33;
        public const int P_ITEM_LINK_TYPEID = 34;
        public const int TRACKH2_TYPEID = 35;
        public const int TRACKH3_TYPEID = 36;
        public const int TRACKHPARAGRAPH_TYPEID = 37;
        public const int REVIEW_ROUTE_TYPEID = 38;
        public const int MEMBER_IMAGE_TYPEID = 39;
        public const int MEMBER_NAME_TYPEID = 40;
        public const int MEMBER_ROLE_TYPEID = 41;
        public const int NAV_SETTINGS_REVIEWS_TYPEID = 42;
        public const int BLOG_TYPEID = 43;
        public const int BLOG_SETTINGS_TYPEID = 44;
        public const int IMAGE_INFO_TYPEID = 49;
        public const int ENG_LANG = 1;

        private async Task<List<ReviewContentDropdownODTO>> ListOfReviews()
        {
            return await _context.Review.Where(x => x.IsActive == true).Select(r => new ReviewContentDropdownODTO
            {
                Value = r.ReviewId,
                Label = r.Name,
                Rating = r.RatingCalculated
            }).OrderByDescending(e => e.Rating).ToListAsync();
        }

        #endregion GlobalFunctions & Statics

        #region Testimonial

        //Testimonial
        private IQueryable<TestimonialODTO> GetTestimonial(int id, int langId)
        {
            return from x in _context.Testimonials
                   .Include(x => x.Language)
                   where (id == 0 || x.TestimonialId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<TestimonialODTO>(x);
        }

        public async Task<List<TestimonialODTO>> Get(int id)
        {
            return await GetTestimonial(id, 0).AsNoTracking().ToListAsync();
        }

        public async Task<List<TestimonialODTO>> GetTestimonialByLanguage(int langId)
        {
            var Testimonial = await GetTestimonial(0, langId).AsNoTracking().ToListAsync();
            YearMonthODTO ym;
            foreach (var item in Testimonial)
            {
                ym = new YearMonthODTO();
                ym = await ChangeDateFormatFront(null, null, null, null, item.TestimonialText, null, langId);
                item.TestimonialText = ym.Content;
            }
            return Testimonial;

        }

        public async Task<List<TestimonialODTO>> EditTestimonial(TestimonialIDTO testimonialIDTO)
        {
            var testimonial = _mapper.Map<Testimonial>(testimonialIDTO);

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, testimonial.TestimonialText, null);
            testimonial.TestimonialText = ym.Content;

            _context.Entry(testimonial).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await Get(testimonial.TestimonialId);
        }

        public async Task<List<TestimonialODTO>> AddTest(TestimonialIDTO testimonialIDTO)
        {
            var testimonial = _mapper.Map<Testimonial>(testimonialIDTO);
            testimonial.TestimonialId = 0;

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, testimonial.TestimonialText, null);
            testimonial.TestimonialText = ym.Content;//Parameter "TestimonialText" will be placed into Context in the function above

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

        private IQueryable<LanguageODTO> GetLanguage(int id/*rmv, string languageName*/)
        {
            return from x in _context.Languages
                   where (id == 0 || x.LanguageId == id)
                   /*rmv && (string.IsNullOrEmpty(languageName) || x.LanguageName.StartsWith(languageName))*/
                   select _mapper.Map<LanguageODTO>(x);
        }

        public async Task<LanguageODTO> GetLanguageById(int id)
        {
            return await GetLanguage(id/*rmv, null*/).AsNoTracking().SingleOrDefaultAsync();
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

        private IQueryable<DataTypeODTO> GetDataType(int id)
        {
            return from x in _context.DataTypes
                   where (id == 0 || x.DataTypeId == id)
                   select _mapper.Map<DataTypeODTO>(x);
        }

        public async Task<DataTypeODTO> GetDataTypeById(int id)
        {
            return await GetDataType(id).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<DataTypeODTO>> GetAllDataTypes()
        {
            return await GetDataType(0).AsNoTracking().ToListAsync();
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

        private IQueryable<NavigationSettingsODTO> GetNavigationSettings(int id)
        {
            return from x in _context.NavigationSettings
                   .Include(x => x.Language)
                   .Include(x => x.HomeRouteLink)
                   where (id == 0 || x.NavigationSettingsId == id)
                   select _mapper.Map<NavigationSettingsODTO>(x);
        }

        public async Task<NavigationSettingsODTO> GetNavigationSettingsById(int id)
        {
            return await GetNavigationSettings(id).FirstOrDefaultAsync();
        }

        public async Task<List<NavigationSettingsByLanguageODTO>> GetNavigationSettingsByLangId(int langId)
        {
            List<NavigationSettingsByLanguageODTO> NavSettings = await (from x in _context.NavigationSettings
                                                                        where x.LanguageId == langId
                                                                        select new NavigationSettingsByLanguageODTO
                                                                        {
                                                                            NavigationSettingsId = x.NavigationSettingsId,
                                                                            LanguageId = x.LanguageId,
                                                                            LanguageName = x.Language.LanguageName,
                                                                            AcademyItem = x.Academy,
                                                                            AcademyLink = x.AcademyRouteLink.URL,
                                                                            BonusItem = x.Bonus,
                                                                            BonusLink = x.BonusRouteLink.URL,
                                                                            HomeItem = x.Home,
                                                                            HomeLink = x.HomeRouteLink.URL,
                                                                            NewsItem = x.News,
                                                                            NewsLink = x.NewsRouteLink.URL,
                                                                            ReviewsItem = x.Reviews,
                                                                            ReviewsLink = x.ReviewsRouteLink.URL,
                                                                            More = x.More,
                                                                            ReviewsRoutes = (from a in _context.SettingsAttributes
                                                                                               .Include(x => x.Language)
                                                                                               .Include(x => x.DataType)
                                                                                               .Include(x => x.SettingsDataType)
                                                                                               .Include(x => x.Url)
                                                                                             where (a.DataTypeId == NAVIGATION_SETTINGS_TYPEID)
                                                                                             && (a.SettingsDataTypeId == REVIEW_ROUTE_TYPEID)
                                                                                             && (a.LanguageId == langId)
                                                                                             select _mapper.Map<SettingsAttributeODTO>(a)).ToList(),
                                                                            Reviews = (from b in _context.SettingsAttributes
                                                                                               .Include(x => x.SettingsDataType)
                                                                                       where (b.DataTypeId == NAVIGATION_SETTINGS_TYPEID)
                                                                                       && (b.SettingsDataTypeId == NAV_SETTINGS_REVIEWS_TYPEID)
                                                                                       && (b.LanguageId == langId)
                                                                                       select _mapper.Map<SettingsAttributeODTO>(b)).ToList(),
                                                                            MoreRoutes = (from b in _context.SettingsAttributes
                                                                                               .Include(x => x.Language)
                                                                                               .Include(x => x.DataType)
                                                                                               .Include(x => x.SettingsDataType)
                                                                                               .Include(x => x.Url)
                                                                                          where (b.DataTypeId == NAVIGATION_SETTINGS_TYPEID)
                                                                                          && (b.SettingsDataTypeId == A_ITEM_ANCHOR_TYPEID || b.SettingsDataTypeId == A_ITEM_LINK_TYPEID)
                                                                                          && (b.LanguageId == langId)
                                                                                          select _mapper.Map<SettingsAttributeODTO>(b)).ToList(),
                                                                        }).ToListAsync();
            return NavSettings;
        }

        public async Task<NavigationSettingsODTO> EditNavigationSettings(NavigationSettingsIDTO navigationSettingsIDTO)
        {
            var navigationSettings = _mapper.Map<NavigationSettings>(navigationSettingsIDTO);
            navigationSettings.BonusRoute = navigationSettings.BonusRoute != 0 ? navigationSettings.BonusRoute : null;
            navigationSettings.ReviewsRoute = navigationSettings.ReviewsRoute != 0 ? navigationSettings.ReviewsRoute : null;
            navigationSettings.NewsRoute = navigationSettings.NewsRoute != 0 ? navigationSettings.NewsRoute : null;
            navigationSettings.HomeRoute = navigationSettings.HomeRoute != 0 ? navigationSettings.HomeRoute : null;
            navigationSettings.AcademyRoute = navigationSettings.AcademyRoute != 0 ? navigationSettings.AcademyRoute : null;
            _context.Entry(navigationSettings).State = EntityState.Modified;

            await SaveContextChangesAsync();
            var settAttr = new SettingsAttribute();
            var urlNames = new string[] { "AcademyRouteUrl", "NewsRouteUrl", "ReviewsRouteUrl", "BonusRouteUrl", "HomeRouteUrl" };
            var propNames = new string[] { "AcademyRoute", "NewsRoute", "ReviewsRoute", "BonusRoute", "HomeRoute" };
            for (int i = 0; i < urlNames.Length; i++)
            {
                if (navigationSettingsIDTO.GetType().GetProperty(urlNames[i])?.GetValue(navigationSettingsIDTO, null) != null)
                {
                    var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == navigationSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(navigationSettingsIDTO, null).ToString().ToLower() && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID && x.TableId == navigationSettingsIDTO.NavigationSettingsId).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                    if (urlid != 0)
                    {
                        navigationSettingsIDTO.GetType().GetProperty(propNames[i]).SetValue(navigationSettingsIDTO, urlid);
                        _context.Entry(navigationSettings).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                            URL = navigationSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(navigationSettingsIDTO, null).ToString(),
                            TableId = navigationSettings.NavigationSettingsId,
                        };
                        _context.UrlTables.Add(url);
                        await _context.SaveChangesAsync();

                        navigationSettings.GetType().GetProperty(propNames[i]).SetValue(navigationSettings, url.UrlTableId);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            /*Old Code if (navigationSettingsIDTO.AcademyRouteUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == navigationSettingsIDTO.AcademyRouteUrl.ToLower() && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    navigationSettings.AcademyRoute = urlid;
                    _context.Entry(navigationSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                        URL = navigationSettingsIDTO.AcademyRouteUrl,
                        TableId = navigationSettings.NavigationSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    navigationSettings.AcademyRoute = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }
            if (navigationSettingsIDTO.NewsRouteUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == navigationSettingsIDTO.NewsRouteUrl.ToLower() && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    navigationSettings.NewsRoute = urlid;
                    _context.Entry(navigationSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                        URL = navigationSettingsIDTO.NewsRouteUrl,
                        TableId = navigationSettings.NavigationSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    navigationSettings.NewsRoute = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }
            if (navigationSettingsIDTO.ReviewsRouteUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == navigationSettingsIDTO.ReviewsRouteUrl.ToLower() && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    navigationSettings.ReviewsRoute = urlid;
                    _context.Entry(navigationSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                        URL = navigationSettingsIDTO.ReviewsRouteUrl,
                        TableId = navigationSettings.NavigationSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    navigationSettings.ReviewsRoute = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }
            if (navigationSettingsIDTO.BonusRouteUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == navigationSettingsIDTO.BonusRouteUrl.ToLower() && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    navigationSettings.BonusRoute = urlid;
                    _context.Entry(navigationSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                        URL = navigationSettingsIDTO.BonusRouteUrl,
                        TableId = navigationSettings.NavigationSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    navigationSettings.BonusRoute = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }
            if (navigationSettingsIDTO.HomeRouteUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == navigationSettingsIDTO.HomeRouteUrl.ToLower() && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    navigationSettings.HomeRoute = urlid;
                    _context.Entry(navigationSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                        URL = navigationSettingsIDTO.HomeRouteUrl,
                        TableId = navigationSettings.NavigationSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    navigationSettings.HomeRoute = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }*/

            if (navigationSettingsIDTO.SettingsAttributes != null)
            {
                foreach (var item in navigationSettingsIDTO.SettingsAttributes)
                {
                    settAttr = new SettingsAttribute
                    {
                        SettingsAttributeId = item.SettingsAttributeId,
                        DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                        SettingsDataTypeId = item.SettingsDataTypeId,
                        LanguageId = item.LanguageId,
                        Value = item.Value,
                        Index = item.Index,
                        UrlTableId = null,
                    };
                    var urlId = await _context.UrlTables.Where(x => x.URL.ToLower() == settAttr.Value && x.DataTypeId == settAttr.DataTypeId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                    settAttr.UrlTableId = settAttr.Value != null && urlId != 0 ? urlId : null;
                    _context.Entry(settAttr).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                    if (settAttr.UrlTableId != null)
                    {
                        if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID))
                        {
                            settAttr.Value = null;
                            await SaveContextChangesAsync();
                        }
                        else
                        {
                            settAttr.UrlTableId = null;
                            await SaveContextChangesAsync();
                        }
                    }
                    else if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = settAttr.DataTypeId,
                            URL = settAttr.Value,
                            TableId = settAttr.SettingsAttributeId,
                        };
                        _context.UrlTables.Add(url);
                        await SaveContextChangesAsync();
                        settAttr.UrlTableId = url.UrlTableId;
                        settAttr.Value = null;
                        await SaveContextChangesAsync();
                    }
                }
            }

            return await GetNavigationSettingsById(navigationSettings.NavigationSettingsId);
        }

        public async Task<NavigationSettingsODTO> AddNavigationSettings(NavigationSettingsIDTO navigationSettingsIDTO)
        {
            var navigationSettings = _mapper.Map<NavigationSettings>(navigationSettingsIDTO);

            navigationSettings.NavigationSettingsId = 0;
            navigationSettings.AcademyRoute = navigationSettings.AcademyRoute != 0 ? navigationSettings.AcademyRoute : null;
            navigationSettings.BonusRoute = navigationSettings.BonusRoute != 0 ? navigationSettings.BonusRoute : null;
            navigationSettings.HomeRoute = navigationSettings.HomeRoute != 0 ? navigationSettings.HomeRoute : null;
            navigationSettings.NewsRoute = navigationSettings.NewsRoute != 0 ? navigationSettings.NewsRoute : null;
            navigationSettings.ReviewsRoute = navigationSettings.ReviewsRoute != 0 ? navigationSettings.ReviewsRoute : null;

            _context.Add(navigationSettings);
            await SaveContextChangesAsync();

            var urlNames = new string[] { "AcademyRouteUrl", "NewsRouteUrl", "ReviewsRouteUrl", "BonusRouteUrl", "HomeRouteUrl" };
            var propNames = new string[] { "AcademyRoute", "NewsRoute", "ReviewsRoute", "BonusRoute", "HomeRoute" };
            for (int i = 0; i < urlNames.Length; i++)
            {
                if (navigationSettingsIDTO.GetType().GetProperty(urlNames[i])?.GetValue(navigationSettingsIDTO, null) != null)
                {
                    var url = new UrlTable
                    {
                        DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                        URL = navigationSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(navigationSettingsIDTO, null).ToString(),
                        TableId = navigationSettings.NavigationSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    navigationSettings.GetType().GetProperty(propNames[i]).SetValue(navigationSettings, url.UrlTableId);
                    await _context.SaveChangesAsync();
                }
            }

            var settAttr = new SettingsAttribute();
            foreach (var item in navigationSettingsIDTO.SettingsAttributes)
            {
                settAttr = new SettingsAttribute
                {
                    DataTypeId = NAVIGATION_SETTINGS_TYPEID,
                    SettingsDataTypeId = item.SettingsDataTypeId,
                    LanguageId = item.LanguageId,
                    Value = item.Value,
                    Index = item.Index,
                    UrlTableId = null,
                };
                var urlId = await _context.UrlTables.Where(x => x.URL.ToLower() == settAttr.Value && x.DataTypeId == settAttr.DataTypeId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                settAttr.UrlTableId = settAttr.Value != null && urlId != 0 ? urlId : null;
                _context.SettingsAttributes.Add(settAttr);
                await SaveContextChangesAsync();
                if (settAttr.UrlTableId != null)
                {
                    settAttr.Value = null;
                    await SaveContextChangesAsync();
                }
                else if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                {
                    var url = new UrlTable
                    {
                        DataTypeId = settAttr.DataTypeId,
                        URL = settAttr.Value,
                        TableId = settAttr.SettingsAttributeId,
                    };
                    _context.UrlTables.Add(url);
                    await SaveContextChangesAsync();
                    settAttr.UrlTableId = url.UrlTableId;
                    settAttr.Value = null;
                    await SaveContextChangesAsync();
                }
            }
            return await GetNavigationSettingsById(navigationSettings.NavigationSettingsId);
        }

        public async Task<NavigationSettingsODTO> DeleteNavigationSettings(int id)
        {
            var navigationSettings = await _context.NavigationSettings.FindAsync(id);
            if (navigationSettings == null) return null;

            var navUrl = await _context.UrlTables.Where(x => x.TableId == navigationSettings.NavigationSettingsId && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID).ToListAsync();
            var navSerp = await _context.Serps.Where(x => x.TableId == navigationSettings.NavigationSettingsId && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID).ToListAsync();
            var navAttr = await _context.SettingsAttributes.Where(x => x.LanguageId == navigationSettings.LanguageId && x.DataTypeId == NAVIGATION_SETTINGS_TYPEID).ToListAsync();

            var navigationSettingsODTO = await GetNavigationSettingsById(id);
            _context.NavigationSettings.Remove(navigationSettings);
            await SaveContextChangesAsync();

            if (navUrl != null)
            {
                foreach (var item in navUrl)
                {
                    _context.UrlTables.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            if (navSerp != null)
            {
                foreach (var item in navSerp)
                {
                    _context.Serps.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            if (navAttr != null)
            {
                foreach (var item in navAttr)
                {
                    var x = await _context.UrlTables.Where(x => x.UrlTableId == item.UrlTableId).FirstOrDefaultAsync();
                    _context.SettingsAttributes.Remove(item);
                    await SaveContextChangesAsync();
                    if (x != null)
                    {
                        _context.UrlTables.Remove(x);
                        await SaveContextChangesAsync();
                    }
                }
            }
            return navigationSettingsODTO;
        }

        #endregion NavigationSettings

        #region FooterSettings

        private IQueryable<FooterSettings> GetFooterSettings(int id)
        {
            return from x in _context.FooterSettings
                   .Include(x => x.Language)
                   where (id == 0 || x.FooterSettingsId == id)
                   select x;
        }

        public async Task<FooterSettingsODTO> GetFooterSettingsById(int id)
        {
            return await _mapper.ProjectTo<FooterSettingsODTO>(GetFooterSettings(id)).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<FooterSettingsODTO>> GetFooterSettingsByLangId(int langId, string UseCase)
        {
            List<FooterSettingsODTO> FootSettings = await (from x in _context.FooterSettings
                                                           where x.LanguageId == langId
                                                           select new FooterSettingsODTO
                                                           {
                                                               FooterSettingsId = x.FooterSettingsId,
                                                               LanguageId = x.LanguageId,
                                                               LanguageName = x.Language.LanguageName,
                                                               FacebookLink = x.FacebookLink,
                                                               FacebookUrl = x.FS_FacebookUrl.URL,
                                                               LinkedInLink = x.LinkedInLink,
                                                               LinkedInUrl = x.FS_LinkedInUrl.URL,
                                                               PodcastLink = x.PodcastLink,
                                                               PodcastUrl = x.FS_PodcastUrl.URL,
                                                               TwitterLink = x.TwitterLink,
                                                               TwitterUrl = x.FS_TwitterUrl.URL,
                                                               YoutubeLink = x.YoutubeLink,
                                                               YoutubeUrl = x.FS_YoutubeUrl.URL,
                                                               CopyrightNotice = x.CopyrightNotice,
                                                               FooterNote = x.FooterNote,
                                                               aItemAnchor = (from a in _context.SettingsAttributes
                                                                              .Include(x => x.Language)
                                                                              .Include(x => x.DataType)
                                                                              .Include(x => x.SettingsDataType)
                                                                              .Include(x => x.Url)
                                                                              where (a.DataTypeId == FOOTER_SETTINGS_TYPEID)
                                                                              && (a.SettingsDataTypeId == A_ITEM_ANCHOR_TYPEID)
                                                                              && (a.LanguageId == langId)
                                                                              select _mapper.Map<SettingsAttributeODTO>(a)).ToList(),
                                                               aItemLink = (from c in _context.SettingsAttributes
                                                                              .Include(x => x.Language)
                                                                              .Include(x => x.DataType)
                                                                              .Include(x => x.SettingsDataType)
                                                                              .Include(x => x.Url)
                                                                            where (c.DataTypeId == FOOTER_SETTINGS_TYPEID)
                                                                            && (c.SettingsDataTypeId == A_ITEM_LINK_TYPEID)
                                                                            && (c.LanguageId == langId)
                                                                            select _mapper.Map<SettingsAttributeODTO>(c)).ToList(),
                                                               pItemLink = (from d in _context.SettingsAttributes
                                                                              .Include(x => x.Language)
                                                                              .Include(x => x.DataType)
                                                                              .Include(x => x.SettingsDataType)
                                                                              .Include(x => x.Url)
                                                                            where (d.DataTypeId == FOOTER_SETTINGS_TYPEID)
                                                                            && (d.SettingsDataTypeId == P_ITEM_LINK_TYPEID)
                                                                            && (d.LanguageId == langId)
                                                                            select _mapper.Map<SettingsAttributeODTO>(d)).ToList(),
                                                               pItemAnchor = (from b in _context.SettingsAttributes
                                                                              .Include(x => x.Language)
                                                                              .Include(x => x.DataType)
                                                                              .Include(x => x.SettingsDataType)
                                                                              .Include(x => x.Url)
                                                                              where (b.DataTypeId == FOOTER_SETTINGS_TYPEID)
                                                                              && (b.SettingsDataTypeId == P_ITEM_ANCHOR_TYPEID)
                                                                              && (b.LanguageId == langId)
                                                                              select _mapper.Map<SettingsAttributeODTO>(b)).ToList(),
                                                           }).ToListAsync();

            YearMonthODTO YM;
            if (UseCase == "Dashboard")
            {
                foreach (var item in FootSettings)
                {
                    YM = new YearMonthODTO();
                    YM = await ChangeDateFormatAdmin(item.FooterNote, item.CopyrightNotice, null, null, null, null);
                    item.FooterNote = YM.SerpTitle;
                    item.CopyrightNotice = YM.SerpDescription;
                }
            }
            else
            {
                foreach (var item in FootSettings)
                {
                    YM = new YearMonthODTO();
                    YM = await ChangeDateFormatFront(item.FooterNote, item.CopyrightNotice, null, null, null, null, item.LanguageId);
                    item.FooterNote = YM.SerpTitle;
                    item.CopyrightNotice = YM.SerpDescription;
                }
            }

            return FootSettings;
        }

        public async Task<FooterSettingsODTO> EditFooterSettings(FooterSettingsIDTO footerSettingsIDTO)
        {
            var footerSettings = _mapper.Map<FooterSettings>(footerSettingsIDTO);
            footerSettings.FacebookLink = footerSettings.FacebookLink != 0 ? footerSettings.FacebookLink : null;
            footerSettings.TwitterLink = footerSettings.TwitterLink != 0 ? footerSettings.TwitterLink : null;
            footerSettings.LinkedInLink = footerSettings.LinkedInLink != 0 ? footerSettings.LinkedInLink : null;
            footerSettings.YoutubeLink = footerSettings.YoutubeLink != 0 ? footerSettings.YoutubeLink : null;
            footerSettings.PodcastLink = footerSettings.PodcastLink != 0 ? footerSettings.PodcastLink : null;

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(footerSettings.CopyrightNotice, footerSettings.FooterNote, null, null, null, null);
            footerSettings.FooterNote = ym.SerpDescription;// Parameter FooterNote was placed into SerpDescription variable inside the function EditDate
            footerSettings.CopyrightNotice = ym.SerpTitle;// Parameter CopyrightNotice was placed into SerpTitle variable inside the function EditDate

            _context.Entry(footerSettings).State = EntityState.Modified;
            await SaveContextChangesAsync();

            var settAttr = new SettingsAttribute();
            var urlNames = new string[] { "FacebookLinkUrl", "TwitterLinkUrl", "LinkedInLinkUrl", "YoutubeLinkUrl", "PodcastLinkUrl" };
            var propNames = new string[] { "FacebookLink", "TwitterLink", "LinkedInLink", "YoutubeLink", "PodcastLink" };

            for (int i = 0; i < urlNames.Length; i++)
            {
                if (footerSettingsIDTO.GetType().GetProperty(urlNames[i])?.GetValue(footerSettingsIDTO, null) != null)
                {
                    var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == footerSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(footerSettingsIDTO, null).ToString().ToLower() && x.DataTypeId == FOOTER_SETTINGS_TYPEID && x.TableId == footerSettingsIDTO.FooterSettingsId).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                    if (urlid != 0)
                    {
                        footerSettings.GetType().GetProperty(propNames[i]).SetValue(footerSettings, urlid);
                        _context.Entry(footerSettings).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = FOOTER_SETTINGS_TYPEID,
                            URL = footerSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(footerSettingsIDTO, null).ToString(),
                            TableId = footerSettings.FooterSettingsId,
                        };
                        _context.UrlTables.Add(url);
                        await _context.SaveChangesAsync();

                        footerSettings.GetType().GetProperty(propNames[i]).SetValue(footerSettings, url.UrlTableId);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            /*Old Code if (footerSettingsIDTO.FacebookLinkUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == footerSettingsIDTO.FacebookLinkUrl.ToLower() && x.DataTypeId == FOOTER_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    footerSettings.FacebookLink = urlid;
                    _context.Entry(footerSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = FOOTER_SETTINGS_TYPEID,
                        URL = footerSettingsIDTO.FacebookLinkUrl,
                        TableId = footerSettings.FooterSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    footerSettings.FacebookLink = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }
            if (footerSettingsIDTO.TwitterLinkUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == footerSettingsIDTO.TwitterLinkUrl.ToLower() && x.DataTypeId == FOOTER_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    footerSettings.TwitterLink = urlid;
                    _context.Entry(footerSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = FOOTER_SETTINGS_TYPEID,
                        URL = footerSettingsIDTO.TwitterLinkUrl,
                        TableId = footerSettings.FooterSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    footerSettings.TwitterLink = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }
            if (footerSettingsIDTO.LinkedInLinkUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == footerSettingsIDTO.LinkedInLinkUrl.ToLower() && x.DataTypeId == FOOTER_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    footerSettings.LinkedInLink = urlid;
                    _context.Entry(footerSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = FOOTER_SETTINGS_TYPEID,
                        URL = footerSettingsIDTO.LinkedInLinkUrl,
                        TableId = footerSettings.FooterSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    footerSettings.LinkedInLink = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }
            if (footerSettingsIDTO.YoutubeLinkUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == footerSettingsIDTO.YoutubeLinkUrl.ToLower() && x.DataTypeId == FOOTER_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    footerSettings.YoutubeLink = urlid;
                    _context.Entry(footerSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = FOOTER_SETTINGS_TYPEID,
                        URL = footerSettingsIDTO.YoutubeLinkUrl,
                        TableId = footerSettings.FooterSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    footerSettings.YoutubeLink = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }
            if (footerSettingsIDTO.PodcastLinkUrl != null)
            {
                var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == footerSettingsIDTO.PodcastLinkUrl.ToLower() && x.DataTypeId == FOOTER_SETTINGS_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                if (urlid != 0)
                {
                    footerSettings.PodcastLink = urlid;
                    _context.Entry(footerSettings).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var url = new UrlTable
                    {
                        DataTypeId = FOOTER_SETTINGS_TYPEID,
                        URL = footerSettingsIDTO.PodcastLinkUrl,
                        TableId = footerSettings.FooterSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    footerSettings.PodcastLink = url.UrlTableId;
                    await _context.SaveChangesAsync();
                }
            }*/

            if (footerSettingsIDTO.SettingsAttributes != null)
            {
                foreach (var item in footerSettingsIDTO.SettingsAttributes)
                {
                    settAttr = new SettingsAttribute
                    {
                        SettingsAttributeId = item.SettingsAttributeId,
                        DataTypeId = FOOTER_SETTINGS_TYPEID,
                        SettingsDataTypeId = item.SettingsDataTypeId,
                        LanguageId = item.LanguageId,
                        Value = item.Value,
                        Index = item.Index,
                        UrlTableId = null,
                    };
                    var urlId = await _context.UrlTables.Where(x => x.URL.ToLower() == settAttr.Value && x.DataTypeId == settAttr.DataTypeId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                    settAttr.UrlTableId = settAttr.Value != null && urlId != 0 ? urlId : null;
                    _context.Entry(settAttr).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                    if (settAttr.UrlTableId != null)
                    {
                        if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID))
                        {
                            settAttr.Value = null;
                            await SaveContextChangesAsync();
                        }
                        else
                        {
                            settAttr.UrlTableId = null;
                            await SaveContextChangesAsync();
                        }
                    }
                    else if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = settAttr.DataTypeId,
                            URL = settAttr.Value,
                            TableId = settAttr.SettingsAttributeId,
                        };
                        _context.UrlTables.Add(url);
                        await SaveContextChangesAsync();
                        settAttr.UrlTableId = url.UrlTableId;
                        settAttr.Value = null;
                        await SaveContextChangesAsync();
                    }
                }
            }

            return await GetFooterSettingsById(footerSettings.FooterSettingsId);
        }

        public async Task<FooterSettingsODTO> AddFooterSettings(FooterSettingsIDTO footerSettingsIDTO)
        {
            var footerSettings = _mapper.Map<FooterSettings>(footerSettingsIDTO);
            footerSettings.FacebookLink = footerSettings.FacebookLink != 0 ? footerSettings.FacebookLink : null;
            footerSettings.TwitterLink = footerSettings.TwitterLink != 0 ? footerSettings.TwitterLink : null;
            footerSettings.LinkedInLink = footerSettings.LinkedInLink != 0 ? footerSettings.LinkedInLink : null;
            footerSettings.YoutubeLink = footerSettings.YoutubeLink != 0 ? footerSettings.YoutubeLink : null;
            footerSettings.PodcastLink = footerSettings.PodcastLink != 0 ? footerSettings.PodcastLink : null;
            footerSettings.FooterSettingsId = 0;

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(footerSettings.CopyrightNotice, footerSettings.FooterNote, null, null, null, null);
            footerSettings.FooterNote = ym.SerpDescription;// Parameter FooterNote was placed into SerpDescription variable inside the function EditDate
            footerSettings.CopyrightNotice = ym.SerpTitle;// Parameter CopyrightNotice was placed into SerpTitle variable inside the function EditDate


            _context.FooterSettings.Add(footerSettings);

            await SaveContextChangesAsync();
            var urlNames = new string[] { "FacebookLinkUrl", "TwitterLinkUrl", "LinkedInLinkUrl", "YoutubeLinkUrl", "PodcastLinkUrl" };
            var propNames = new string[] { "FacebookLink", "TwitterLink", "LinkedInLink", "YoutubeLink", "PodcastLink" };

            for (int i = 0; i < urlNames.Length; i++)
            {
                if (footerSettingsIDTO.GetType().GetProperty(urlNames[i])?.GetValue(footerSettingsIDTO, null) != null)
                {
                    var url = new UrlTable
                    {
                        DataTypeId = FOOTER_SETTINGS_TYPEID,
                        URL = footerSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(footerSettingsIDTO, null).ToString(),
                        TableId = footerSettings.FooterSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    footerSettings.GetType().GetProperty(propNames[i]).SetValue(footerSettings, url.UrlTableId);
                    await _context.SaveChangesAsync();
                }
            }
            var settAttr = new SettingsAttribute();
            if (footerSettingsIDTO.SettingsAttributes != null)
            {
                foreach (var item in footerSettingsIDTO.SettingsAttributes)
                {
                    settAttr = new SettingsAttribute
                    {
                        DataTypeId = FOOTER_SETTINGS_TYPEID,
                        SettingsDataTypeId = item.SettingsDataTypeId,
                        LanguageId = item.LanguageId,
                        Value = item.Value,
                        Index = item.Index,
                        UrlTableId = null,
                    };
                    _context.SettingsAttributes.Add(settAttr);
                    await SaveContextChangesAsync();
                    if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                    {
                        var urlId = await _context.UrlTables.Where(x => x.URL.ToLower() == settAttr.Value && x.DataTypeId == settAttr.DataTypeId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                        settAttr.UrlTableId = settAttr.Value != null && urlId != 0 ? urlId : null;
                        await SaveContextChangesAsync();
                    }
                    if (settAttr.UrlTableId != null)
                    {
                        settAttr.Value = null;
                        await SaveContextChangesAsync();
                    }
                    else if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = settAttr.DataTypeId,
                            URL = settAttr.Value,
                            TableId = settAttr.SettingsAttributeId,
                        };
                        _context.UrlTables.Add(url);
                        await SaveContextChangesAsync();
                        settAttr.UrlTableId = url.UrlTableId;
                        settAttr.Value = null;
                        await SaveContextChangesAsync();
                    }
                }
            }
            return await GetFooterSettingsById(footerSettings.FooterSettingsId);
        }

        public async Task<FooterSettingsODTO> DeleteFooterSettings(int id)
        {
            var footerSettings = await _context.FooterSettings.FindAsync(id);
            if (footerSettings == null) return null;

            var footAttr = await _context.SettingsAttributes.Where(x => x.LanguageId == footerSettings.LanguageId && x.DataTypeId == FOOTER_SETTINGS_TYPEID).ToListAsync();
            var footUrl = await _context.UrlTables.Where(x => x.TableId == footerSettings.FooterSettingsId && x.DataTypeId == FOOTER_SETTINGS_TYPEID).ToListAsync();

            var footerSettingsODTO = await GetFooterSettingsById(id);
            _context.FooterSettings.Remove(footerSettings);
            await SaveContextChangesAsync();

            if (footUrl != null)
            {
                foreach (var item in footUrl)
                {
                    _context.UrlTables.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            if (footAttr != null)
            {
                var x = new List<UrlTable>();
                foreach (var item in footAttr)
                {
                    if (item.UrlTableId != 0)
                    {
                        var y = await _context.UrlTables.Where(x => x.UrlTableId == item.UrlTableId).FirstOrDefaultAsync();
                        x.Add(y);
                    }
                    _context.SettingsAttributes.Remove(item);
                    await SaveContextChangesAsync();
                }
                foreach (var item in x)
                {
                    _context.UrlTables.Remove(item);
                    await SaveContextChangesAsync();
                }
            }

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

        public async Task<List<ReviewAttributeODTO>> GetReviewAttributeByReviewID(int ReviewId)
        {
            List<ReviewAttributeODTO> reviews = await (from x in _context.ReviewAttributes
                                                       .Include(x => x.DataType)
                                                       .Include(x => x.Review)
                                                       where x.ReviewId == ReviewId
                                                       select new ReviewAttributeODTO
                                                       {
                                                           ReviewAttributeId = x.ReviewAttributeId,
                                                           ReviewId = x.ReviewId,
                                                           Name = x.Review.Name,
                                                           DataTypeId = x.DataTypeId,
                                                           DataTypeName = x.DataType.DataTypeName,
                                                           Index = x.Index,
                                                           Value = x.Value
                                                       }).ToListAsync();
            return reviews;
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

        public async Task<List<ReviewAttributeODTO>> EditReviewAttributes(List<ReviewAttributeIDTO> reviewAttributeIDTO)
        {
            var reviewAttributes = reviewAttributeIDTO.Select(x => _mapper.Map<ReviewAttribute>(x)).ToList();

            foreach (var revAttr in reviewAttributes)
            {
                if (revAttr.ReviewAttributeId != 0)
                {
                    _context.Entry(revAttr).State = EntityState.Modified;
                }
                else
                {
                    revAttr.ReviewAttributeId = 0;
                    _context.ReviewAttributes.Add(revAttr);
                }
            }
            await SaveContextChangesAsync();

            return reviewAttributes.Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList();
        }

        public async Task<List<ReviewAttributeODTO>> AddReviewAttributes(List<ReviewAttributeIDTO> reviewAttributeIDTO)
        {
            var reviewAttributes = reviewAttributeIDTO.Select(x => _mapper.Map<ReviewAttribute>(x)).ToList();

            foreach (var revAttr in reviewAttributes)
            {
                revAttr.ReviewAttributeId = 0;
                _context.ReviewAttributes.Add(revAttr);
            }
            await SaveContextChangesAsync();

            return reviewAttributes.Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList();
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

        public async Task<List<GetUrlODTO>> GetUrl(string url)
        {
            return await (from x in _context.Routes
                         .Include(x => x.DataType)
                         .Include(x => x.UrlTable)
                          where (x.UrlTable.URL == url)
                          select new GetUrlODTO
                          {
                              UrlTableID = x.UrlTableId,
                              Url = x.UrlTable.URL,
                              DataTypeID = x.DataTypeId,
                              DataTypeName = x.DataType.DataTypeName,
                              LanguageID = x.LanguageId,
                              TableId = x.TableId,
                          }).ToListAsync();
        }

        public async Task<List<GetUrlTableByDataTypeIdAndLangODTO>> GetUrlTableByDataTypeIdAndLang(int dataTypeId, int langId)
        {
            switch (dataTypeId)
            {
                case REVIEW_TYPEID:
                    return await _context.Review.Where(x => x.LanguageId == langId && x.IsActive == true).Select(x =>
                    new GetUrlTableByDataTypeIdAndLangODTO
                    {
                        UrlTableId = new List<int?> { x.FacebookUrl, x.TwitterUrl, x.InstagramUrl, x.LinkedInUrl, x.YoutubeUrl, x.ReportLink },
                        URL = new List<string> { x.Rev_FacebookUrl.URL, x.Rev_TwitterUrl.URL, x.Rev_InstagramUrl.URL, x.Rev_LinkedInUrl.URL, x.Rev_YoutubeUrl.URL, x.Rev_ReportLink.URL },
                        LanguageId = x.LanguageId,
                        LanguageName = x.Language.LanguageName
                    }).ToListAsync();

                case ACADEMY_TYPEID:
                    return await _context.Academies.Where(x => x.LanguageId == langId).Select(x =>
                   new GetUrlTableByDataTypeIdAndLangODTO
                   {
                       UrlTableId = new List<int?> { x.UrlTableId },
                       URL = new List<string> { x.UrlTable.URL },
                       LanguageId = (int)x.LanguageId,
                       LanguageName = x.Language.LanguageName
                   }).ToListAsync();

                case LINKS_TYPEID:
                    return await _context.Links.Where(x => x.LanguageId == langId).Select(x =>
                    new GetUrlTableByDataTypeIdAndLangODTO
                    {
                        UrlTableId = new List<int?> { x.UrlTableId },
                        URL = new List<string> { x.UrlTable.URL },
                        LanguageId = x.LanguageId,
                        LanguageName = x.Language.LanguageName
                    }).ToListAsync();

                case NEWS_FEED_TYPEID:
                    return await _context.NewsFeeds.Where(x => x.LanguageId == langId).Select(x =>
                    new GetUrlTableByDataTypeIdAndLangODTO
                    {
                        UrlTableId = new List<int?> { x.UrlTableId },
                        URL = new List<string> { x.UrlTable.URL },
                        LanguageId = x.LanguageId,
                        LanguageName = x.Language.LanguageName
                    }).ToListAsync();

                case ROUTES_TYPEID:
                    return await _context.Routes.Where(x => x.LanguageId == langId).Select(x =>
                    new GetUrlTableByDataTypeIdAndLangODTO
                    {
                        UrlTableId = new List<int?> { x.UrlTableId },
                        URL = new List<string> { x.UrlTable.URL },
                        LanguageId = x.LanguageId,
                        LanguageName = x.Language.LanguageName
                    }).ToListAsync();

                case HOME_SETTINGS_TYPEID:
                    return await _context.HomeSettings.Where(x => x.LanguageId == langId).Select(x =>
                   new GetUrlTableByDataTypeIdAndLangODTO
                   {
                       UrlTableId = new List<int?> { x.NewsUrl, x.AcademyUrl, x.BonusUrl },
                       URL = new List<string> { x.NewsUrls.URL, x.ReviewUrls.URL, x.AcademyUrls.URL, x.BonusUrls.URL },
                       LanguageId = (int)x.LanguageId,
                       LanguageName = x.Language.LanguageName
                   }).ToListAsync();

                default: return null;
            }
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
            var url = await _context.UrlTables.FindAsync(id);
            if (url == null) return null;

            var urlODTO = await GetUrlTableById(id);
            _context.UrlTables.Remove(url);
            await SaveContextChangesAsync();
            return urlODTO;
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
            var url = new UrlTable
            {
                DataTypeId = LINKS_TYPEID,
                URL = linkIDTO.UrlTableName
            };
            _context.UrlTables.Add(url);
            await SaveContextChangesAsync();

            links.UrlTableId = url.UrlTableId;
            _context.Entry(links).State = EntityState.Modified;

            await SaveContextChangesAsync();
            url.TableId = links.LinkId;
            await SaveContextChangesAsync();

            return await GetLinkById(links.LinkId);
        }

        public async Task<LinkODTO> AddLink(LinkIDTO linkIDTO)
        {
            var links = _mapper.Map<Links>(linkIDTO);
            var url = new UrlTable
            {
                DataTypeId = LINKS_TYPEID,
                URL = linkIDTO.UrlTableName
            };
            _context.UrlTables.Add(url);
            await SaveContextChangesAsync();

            links.LinkId = 0;
            links.UrlTableId = url.UrlTableId;
            _context.Links.Add(links);
            await SaveContextChangesAsync();

            url.TableId = links.LinkId;
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

        public async Task<CashBackODTO> GetCashBackFull(int id)
        {
            var gu = await _context.UrlLanguages.Where(x => x.TableID == id).Select(x => x.GUID).ToListAsync();

            return await (from x in _context.CashBacks
                   .Include(x => x.Language)
                   .Include(x => x.Review)
                          where (id == 0 || x.CashBackId == id)
                          select new CashBackODTO
                          {
                              CashBackId = x.CashBackId,
                              CashBack_ca = x.CashBack_ca,
                              CashBack_terms = x.CashBack_terms,
                              IsCampaign = x.IsCampaign,
                              LanguageId = x.LanguageId,
                              LanguageName = x.Language.LanguageName,
                              Exclusive = x.Exclusive,
                              ReviewId = Convert.ToInt32(x.ReviewId),
                              Name = x.Review.Name,
                              Valid_Until = x.Valid_Until,
                              UO = (from y in _context.UrlLanguages
                                    where (gu.Contains(y.GUID))
                                    select _mapper.Map<UrlLanguagesODTO>(y)).ToList()
                          }).SingleOrDefaultAsync();
        }

        public async Task<CashBackODTO> GetCashBackById(int id)
        {
            var cashback=  await GetCashBack(id, 0).AsNoTracking().SingleOrDefaultAsync();
            YearMonthODTO ym = new YearMonthODTO();
            ym = await ChangeDateFormatAdmin(null, null, null, null, cashback.CashBack_ca, cashback.CashBack_terms);
            cashback.CashBack_ca = ym.Content;
            cashback.CashBack_terms = ym.Title;
            return cashback;
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
                                   join r in _context.Review on x.ReviewId equals r.ReviewId
                                   where x.LanguageId == langId && x.IsCampaign == isCampaign && r.IsActive == true
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
                               where d.LanguageId == langId && x.IsCampaign == false && d.IsActive == true
                               select new GetCampaignBonusODTO
                               {
                                   CashBackId = x.CashBackId,
                                   ReviewId = d.ReviewId,
                                   Exclusive = x.Exclusive,
                                   ValidUntil = x.Valid_Until,
                                   Name = d.Name,
                                   Logo = d.Logo,
                                   Count = d.Count,
                                   CashbackCta = x.CashBack_ca,
                                   Stars = (decimal)(((d.RiskReturn != null ? d.RiskReturn : 0) + (d.Usability != null ? d.Usability : 0) +
                                               (d.Liquidity != null ? d.Liquidity : 0) + (d.Support != null ? d.Support : 0)) / 4),
                                   ExternalLinkKey = d.Name.ToLower(),
                                   ReviewUrlId = _context.Routes.FirstOrDefault(e => e.DataTypeId == REVIEW_TYPEID && e.TableId == d.ReviewId).UrlTableId,
                                   Terms = x.CashBack_terms,
                                   ReviewBoxThree = new ReviewBoxThreeODTO
                                   {
                                       BuybackGuarantee = d.BuybackGuarantee,
                                       AutoInvest = d.AutoInvest,
                                       Secondarymarket = d.SecondaryMarket,
                                       Cashback = d.CashbackBonus,
                                       Promotion = d.Promotion
                                   },
                                   ReviewBoxFour = new ReviewBoxFourODTO
                                   {
                                       MinInvestment = d.DiversificationMinInvest,
                                       Country = d.Countries,
                                       LoanOriginators = d.LoanOriginators,
                                       LoanType = d.LoanType,
                                       LoanPeriod = string.Format("{0} - {1}", d.MinLoanPerion, d.MaxLoanPerion),
                                       Interest = d.InterestRange,
                                       Currency = d.StatisticsCurrency
                                   },
                                   ReviewBoxFive = new ReviewBoxFiveODTO
                                   {
                                       Benefits = _context.ReviewAttributes.Where(x => x.ReviewId == d.ReviewId && x.DataTypeId == BENEFIT_ATTR_TYPEID).Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList(),
                                       Disadvantages = _context.ReviewAttributes.Where(x => x.ReviewId == d.ReviewId && x.DataTypeId == DISSADVANTAGE_ATTR_TYPEID).Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList()
                                   }
                               }).OrderByDescending(e => e.Stars).ToListAsync();

            var campaign = await (from x in _context.CashBacks
                                  join r in _context.Review on x.ReviewId equals r.ReviewId into a
                                  from d in a.DefaultIfEmpty()
                                  where d.LanguageId == langId && x.IsCampaign == true && d.IsActive == true
                                  select new GetCampaignBonusODTO
                                  {
                                      CashBackId = x.CashBackId,
                                      ReviewId = d.ReviewId,
                                      Exclusive = x.Exclusive,
                                      ValidUntil = x.Valid_Until,
                                      Name = d.Name,
                                      Logo = d.Logo,
                                      Count = d.Count,
                                      CashbackCta = x.CashBack_ca,
                                      Stars = (decimal)(((d.RiskReturn != null ? d.RiskReturn : 0) + (d.Usability != null ? d.Usability : 0) +
                                         (d.Liquidity != null ? d.Liquidity : 0) + (d.Support != null ? d.Support : 0)) / 4),
                                      ExternalLinkKey = d.Name.ToLower(),
                                      ReviewUrlId = _context.Routes.FirstOrDefault(e => e.DataTypeId == REVIEW_TYPEID && e.TableId == d.ReviewId).UrlTableId,
                                      Terms = x.CashBack_terms,
                                  }).OrderByDescending(e => e.Stars).ToListAsync();

            YearMonthODTO ym;
            foreach (var item in offer)
            {
                ym = new YearMonthODTO();
                ym = await ChangeDateFormatFront(null, item.Terms, null, null, null, item.CashbackCta, langId);
                item.CashbackCta = ym.Title;
                item.Terms = ym.SerpDescription;
            }

            foreach (var item in campaign)
            {
                ym = new YearMonthODTO();
                ym = await ChangeDateFormatFront(null, item.Terms, null, null, null, item.CashbackCta, langId);
                item.CashbackCta = ym.Title;
                item.Terms = ym.SerpDescription;
            }
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
                if (cashBack.Valid_Until != null)
                {
                    cashBack.Exclusive = null;
                }
            }
            else
            {
                if (cashBack.Exclusive != null)
                {
                    cashBack.Valid_Until = null;
                }
            }

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, cashBack.CashBack_terms, null, null, null, cashBack.CashBack_ca);
            cashBack.CashBack_terms = ym.SerpDescription;
            cashBack.CashBack_ca = ym.Title;

            _context.Entry(cashBack).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetCashBackById(cashBack.CashBackId);
        }

        public async Task<CashBackODTO> AddCashBack(CashBackIDTO cashBackIDTO)
        {
            var cashBack = _mapper.Map<CashBack>(cashBackIDTO);
            if (cashBack.IsCampaign)
            {
                if (cashBack.Valid_Until != null)
                {
                    cashBack.Exclusive = null;
                    cashBack.Valid_Until = DateTime.Now;
                }
            }
            else
            {
                if (cashBack.Exclusive != null)
                {
                    cashBack.Valid_Until = null;
                }
            }

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, cashBack.CashBack_terms, null, null, null, cashBack.CashBack_ca);
            cashBack.CashBack_terms = ym.SerpDescription;
            cashBack.CashBack_ca = ym.Title;

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
            var urlRoute = await _context.UrlTables.Where(x => x.URL == routesIDTO.UrlTableName && x.DataTypeId == ROUTES_TYPEID).FirstOrDefaultAsync();

            if (urlRoute == null)
            {
                var url = new UrlTable
                {
                    DataTypeId = ROUTES_TYPEID,
                    URL = routesIDTO.UrlTableName
                };
                _context.UrlTables.Add(url);
                await SaveContextChangesAsync();

                routes.UrlTableId = url.UrlTableId;
                _context.Entry(routes).State = EntityState.Modified;

                await SaveContextChangesAsync();
                url.TableId = routes.RoutesId;
                await SaveContextChangesAsync();
            }
            else
            {
                routes.UrlTableId = urlRoute.UrlTableId;
                _context.Entry(routes).State = EntityState.Modified;
                await SaveContextChangesAsync();

                urlRoute.TableId = routes.RoutesId;
                await SaveContextChangesAsync();
            }

            return await GetRoutesById(routes.RoutesId);
        }

        public async Task<RoutesODTO> AddRoute(RoutesIDTO routesIDTO)
        {
            var routes = _mapper.Map<Routes>(routesIDTO);
            var urlRoute = await _context.UrlTables.Where(x => x.URL == routesIDTO.UrlTableName && x.DataTypeId == ROUTES_TYPEID).FirstOrDefaultAsync();

            if (urlRoute == null)
            {
                var url = new UrlTable
                {
                    DataTypeId = ROUTES_TYPEID,
                    URL = routesIDTO.UrlTableName
                };
                _context.UrlTables.Add(url);
                await SaveContextChangesAsync();

                routes.RoutesId = 0;
                routes.UrlTableId = url.UrlTableId;
                _context.Routes.Add(routes);
                await SaveContextChangesAsync();

                url.TableId = routes.RoutesId;
                await SaveContextChangesAsync();
            }
            else
            {
                routes.RoutesId = 0;
                routes.UrlTableId = urlRoute.UrlTableId;
                _context.Routes.Add(routes);
                await SaveContextChangesAsync();

                urlRoute.TableId = routes.RoutesId;
                await SaveContextChangesAsync();
            }
            await AddUrlLanguage(routesIDTO.Link /*link za proveru*/, routesIDTO.DataTypeId, routesIDTO.UrlTableName /*Link koji se upisuje u tabelu*/, routesIDTO.LanguageId, routesIDTO.TableId);

            return await GetRoutesById(routes.RoutesId);
        }

        public async Task<RoutesODTO> DeleteRoute(int id)
        {
            var routes = await _context.Routes.FindAsync(id);
            if (routes == null) return null;

            var routesUrl = await _context.UrlTables.Where(x => x.TableId == routes.RoutesId && x.DataTypeId == ROUTES_TYPEID).ToListAsync();

            var routesODTO = await GetRoutesById(id);
            _context.Routes.Remove(routes);
            await SaveContextChangesAsync();

            if (routesUrl != null)
            {
                foreach (var item in routesUrl)
                {
                    _context.UrlTables.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            return routesODTO;
        }

        public async Task<List<GetDropdownValuesODTO>> GetDropdownValues(string DataTypeName, int lang)
        {
            var dataTypeId = await _context.DataTypes.Where(x => x.DataTypeName.ToLower() == DataTypeName.ToLower()).Select(x => x.DataTypeId).FirstOrDefaultAsync();

            switch (dataTypeId)
            {
                case REVIEW_TYPEID:
                    return await (from x in _context.Review
                                  where x.LanguageId == lang && x.IsActive == true
                                  select new GetDropdownValuesODTO
                                  {
                                      Value = "review_" + x.ReviewId.ToString(),
                                      Name = x.Name,
                                  }).OrderByDescending(x => x.Value).ToListAsync();

                case ACADEMY_TYPEID:
                    return await (from x in _context.Pages
                                  where (x.LanguageId == lang && x.DataTypeId == ACADEMY_TYPEID)
                                  select new GetDropdownValuesODTO
                                  {
                                      Value = "pages__" + x.PageId.ToString(),
                                      Name = x.PageTitle,
                                  }).OrderByDescending(x => x.Value).ToListAsync();

                case CASHBACK_BONUS_TYPEID:
                    return await (from x in _context.Pages
                                  where (x.LanguageId == lang && x.DataTypeId == CASHBACK_BONUS_TYPEID)
                                  select new GetDropdownValuesODTO
                                  {
                                      Value = "pages__" + x.PageId.ToString(),
                                      Name = x.PageTitle,
                                  }).OrderByDescending(x => x.Value).ToListAsync();

                case GENERAL_TYPEID:
                    return await (from x in _context.Pages
                                  where (x.LanguageId == lang && x.DataTypeId == GENERAL_TYPEID)
                                  select new GetDropdownValuesODTO
                                  {
                                      Value = "pages__" + x.PageId.ToString(),
                                      Name = x.PageTitle,
                                  }).OrderByDescending(x => x.Value).ToListAsync();

                case ABOUT_TYPEID:
                    return await (from x in _context.Pages
                                  where (x.LanguageId == lang && x.DataTypeId == ABOUT_TYPEID)
                                  select new GetDropdownValuesODTO
                                  {
                                      Value = "pages__" + x.PageId.ToString(),
                                      Name = x.PageTitle,
                                  }).OrderByDescending(x => x.Value).ToListAsync();

                case BLOG_TYPEID:
                    return await (from x in _context.Blogs
                                  where (x.LanguageId == lang)
                                  select new GetDropdownValuesODTO
                                  {
                                      Value = "blogs_" + x.BlogId.ToString(),
                                      Name = x.PageTitle,
                                  }).OrderByDescending(x => x.Value).ToListAsync();

                default:
                    return null;
            }
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
            var serp = await GetSerp(id, 0).AsNoTracking().FirstOrDefaultAsync();

            YearMonthODTO ym = new YearMonthODTO();
            ym = await ChangeDateFormatAdmin(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, null);
            serp.SerpTitle = ym.SerpTitle;
            serp.Subtitle = ym.Subtitle;
            serp.SerpDescription = ym.SerpDescription;
            return serp;
        }

        public async Task<List<SerpODTO>> GetByDataTypeId(int dataTypeId)
        {
            return await GetSerp(0, dataTypeId).ToListAsync();
        }

        public async Task<SerpODTO> EditSerp(SerpIDTO serpIDTO)
        {
            var serp = _mapper.Map<Serp>(serpIDTO);
            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, null);

            serp.SerpTitle = ym.SerpTitle;
            serp.Subtitle = ym.Subtitle;
            serp.SerpDescription = ym.SerpDescription;

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
            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, null);

            serp.SerpTitle = ym.SerpTitle;
            serp.Subtitle = ym.Subtitle;
            serp.SerpDescription = ym.SerpDescription;
            _context.Entry(serp).State = EntityState.Modified;//Mozda nece raditi bez ovoga
            await SaveContextChangesAsync();
            switch (serpIDTO.DataTypeId)
            {
                case REVIEW_TYPEID:
                    var rev = await _context.Review.Where(x => x.ReviewId == serp.TableId && x.IsActive == true).FirstOrDefaultAsync();
                    if (rev != null)
                    {
                        rev.SerpId = serp.SerpId;
                        await SaveContextChangesAsync();
                    }
                    break;

                case ACADEMY_TYPEID:
                    var acd = await _context.Academies.Where(x => x.AcademyId == serp.TableId).FirstOrDefaultAsync();
                    if (acd != null)
                    {
                        acd.SerpId = serp.SerpId;
                        await SaveContextChangesAsync();
                    }
                    break;

                case PAGES_TYPEID:
                    var page = await _context.Pages.Where(x => x.PageId == serp.TableId).FirstOrDefaultAsync();
                    if (page != null)
                    {
                        page.SerpId = serp.SerpId;
                        await SaveContextChangesAsync();
                    }
                    break;

                case HOME_SETTINGS_TYPEID:
                    var homeSett = await _context.HomeSettings.Where(x => x.HomeSettingsId == serp.TableId).FirstOrDefaultAsync();
                    if (homeSett != null)
                    {
                        homeSett.SerpId = serp.SerpId;
                        await SaveContextChangesAsync();
                    }
                    break;

                case ABOUT_SETTINGS_TYPEID:
                    var aboutSett = await _context.AboutSettings.Where(x => x.AboutSettingsId == serp.TableId).FirstOrDefaultAsync();
                    if (aboutSett != null)
                    {
                        aboutSett.SerpId = serp.SerpId;
                        await SaveContextChangesAsync();
                    }
                    break;

                case REVIEW_SETTINGS_TYPEID:
                    var revSett = await _context.PagesSettings.Where(x => x.PagesSettingsId == serp.TableId).FirstOrDefaultAsync();
                    if (revSett != null)
                    {
                        revSett.SerpId = serp.SerpId;
                        await SaveContextChangesAsync();
                    }
                    break;

                case ACADEMY_SETTINGS_TYPEID:
                    var acdSett = await _context.PagesSettings.Where(x => x.PagesSettingsId == serp.TableId).FirstOrDefaultAsync();
                    if (acdSett != null)
                    {
                        acdSett.SerpId = serp.SerpId;
                        await SaveContextChangesAsync();
                    }
                    break;

                case NEWS_SETTINGS_TYPEID:
                    var newsSett = await _context.PagesSettings.Where(x => x.PagesSettingsId == serp.TableId).FirstOrDefaultAsync();
                    if (newsSett != null)
                    {
                        newsSett.SerpId = serp.SerpId;
                        await SaveContextChangesAsync();
                    }
                    break;

                case BONUS_SETTINGS_TYPEID:
                    var bonusSett = await _context.PagesSettings.Where(x => x.PagesSettingsId == serp.TableId).FirstOrDefaultAsync();
                    if (bonusSett != null)
                    {
                        bonusSett.SerpId = serp.SerpId;
                    }
                    break;

                default:
                    break;
            }
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

        private IQueryable<FaqTitleODTO> GetFaqTitle(int id)
        {
            return from x in _context.FaqTitles
                   .Include(x => x.Page)
                   .Include(x => x.Blog)
                   where (id == 0 || x.FaqTitleId == id)
                   select _mapper.Map<FaqTitleODTO>(x);
        }

        public async Task<FaqTitleODTO> GetFaqTitleById(int id)
        {
            return await GetFaqTitle(id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<GetFaqTitleByReviewIdODTO>> GetFaqTitleByReviewId(int reviewId)
        {
            var Faq = await (from x in _context.FaqTitles
                             where (reviewId == 0 || x.ReviewId == reviewId)
                             && x.ReviewId != null
                             select _mapper.Map<GetFaqTitleByReviewIdODTO>(x)).ToListAsync();

            YearMonthODTO ym;
            foreach (var item in Faq)
            {
                ym = new YearMonthODTO();
                var LanguageId = await _context.FaqTitles.Include(x => x.Review).Where(x => x.ReviewId == item.ReviewId).Select(x => x.Review.LanguageId).FirstOrDefaultAsync();
                ym = await ChangeDateFormatFront(null, null, null, null, null, item.Title, LanguageId);
                if (ym != null)
                {
                    item.Title = ym.Title;
                }
            }
            return Faq;

        }

        public async Task<List<GetFaqTitleByPageIdODTO>> GetFaqTitleByPageId(int pageId)
        {
            var FaqTitleByPageId = await (from x in _context.FaqTitles
                                          where (pageId == 0 || x.PageId == pageId)
                                          && x.PageId != null
                                          select _mapper.Map<GetFaqTitleByPageIdODTO>(x)).ToListAsync();
            YearMonthODTO ym;
            foreach (var item in FaqTitleByPageId)
            {
                ym = new YearMonthODTO();
                var LanguageId = await _context.Pages.Where(x => x.PageId == item.PageId).Select(x => x.LanguageId).FirstOrDefaultAsync();
                ym = await ChangeDateFormatFront(null, null, null, null, null, item.Title, LanguageId);
                item.Title = ym.Title;
            }
            return FaqTitleByPageId;
        }

        public async Task<List<GetFaqTitleByBlogIdODTO>> GetFaqTitleByBlogId(int blogId)
        {
            var FaqTitleByBlog = await (from x in _context.FaqTitles
                                        where (blogId == 0 || x.BlogId == blogId)
                                        && x.BlogId != null
                                        select _mapper.Map<GetFaqTitleByBlogIdODTO>(x)).ToListAsync();
            YearMonthODTO ym;
            foreach (var item in FaqTitleByBlog)
            {
                ym = new YearMonthODTO();
                var LanguageId = await _context.Blogs.Where(x => x.BlogId == item.BlogId).Select(x => x.LanguageId).FirstOrDefaultAsync();
                ym = await ChangeDateFormatFront(null, null, null, null, null, item.Title, LanguageId);
                item.Title = ym.Title;
            }
            return FaqTitleByBlog;
        }

        public async Task<FaqTitleODTO> EditFaqTitle(FaqTitleIDTO faqTitleIDTO)
        {
            var faqTitle = _mapper.Map<FaqTitle>(faqTitleIDTO);

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, null, faqTitle.Title);
            faqTitle.Title = ym.Title;

            _context.Entry(faqTitle).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await GetFaqTitleById(faqTitle.FaqTitleId);
        }

        public async Task<FaqTitleODTO> AddFaqTitle(FaqTitleIDTO faqTitleIDTO)
        {
            var faqTitle = _mapper.Map<FaqTitle>(faqTitleIDTO);

            faqTitle.FaqTitleId = 0;

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, null, faqTitle.Title);
            faqTitle.Title = ym.Title;

            _context.FaqTitles.Add(faqTitle);
            await SaveContextChangesAsync();

            return await GetFaqTitleById(faqTitle.FaqTitleId);
        }

        public async Task<List<FaqTitleODTO>> AddFaqTitles(List<FaqTitleIDTO> faqTitleIDTO)
        {
            var faqTitles = faqTitleIDTO.Select(x => _mapper.Map<FaqTitle>(x)).ToList();

            foreach (var faqTitle in faqTitles)
            {
                faqTitle.FaqTitleId = 0;
                faqTitle.ReviewId = faqTitle.ReviewId == 0 ? faqTitle.ReviewId = null : faqTitle.ReviewId;
                faqTitle.PageId = faqTitle.PageId == 0 ? faqTitle.PageId = null : faqTitle.PageId;
                _context.FaqTitles.Add(faqTitle);
            }
            await SaveContextChangesAsync();

            return faqTitles.Select(x => _mapper.Map<FaqTitleODTO>(x)).ToList();
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
            var FaqList = await GetFaqList(0, faqTitleId).ToListAsync();

            YearMonthODTO ym;
            foreach (var item in FaqList)
            {
                /*var LanguageId = await _context.FaqTitles.Include(x=> x.Review).Where(x=> x.FaqTitleId == item.FaqTitleId).SingleOrDefaultAsync();*/
                var LanguageId = await (from x in _context.FaqTitles
                                        join r in _context.Review on x.ReviewId equals r.ReviewId
                                        select r.LanguageId).FirstOrDefaultAsync();
                ym = new YearMonthODTO();
                ym = await ChangeDateFormatFront(null, null, null, null, item.Question, item.Answer, LanguageId);
                item.Answer = ym.Title;
                item.Question = ym.Content;
            }
            return FaqList;
        }

        public async Task<List<FaqListODTO>> GetFaqListByPageTitleId(int faqTitleId)
        {
            var blog = await _context.FaqTitles.Where(x => x.FaqTitleId == faqTitleId).FirstOrDefaultAsync();
            if (blog.PageId != null)
                return await GetFaqList(0, faqTitleId).ToListAsync();
            return null;
        }

        public async Task<List<FaqListODTO>> GetFaqListByBlogTitleId(int faqTitleId, string UseCase)
        {
            var blog = await _context.FaqTitles.Where(x => x.FaqTitleId == faqTitleId).FirstOrDefaultAsync();
            if (blog.BlogId != null)
            {
                var FaqList = await GetFaqList(0, faqTitleId).ToListAsync();
                YearMonthODTO ym;
                foreach (var item in FaqList)
                {
                    /*var LanguageId = await _context.FaqTitles.Include(x=> x.Review).Where(x=> x.FaqTitleId == item.FaqTitleId).SingleOrDefaultAsync();*/
                    var LanguageId = await (from x in _context.FaqTitles
                                            join r in _context.Review on x.ReviewId equals r.ReviewId
                                            select r.LanguageId).FirstOrDefaultAsync();

                    if (UseCase == "Dashboard")
                    {
                        ym = new YearMonthODTO();
                        ym = await ChangeDateFormatAdmin(null, null, null, null, item.Question, item.Answer);
                        item.Answer = ym.Title;
                        item.Question = ym.Content;
                    }
                    else
                    {
                        ym = new YearMonthODTO();
                        ym = await ChangeDateFormatFront(null, null, null, null, item.Question, item.Answer, LanguageId);
                        item.Answer = ym.Title;
                        item.Question = ym.Content;
                    }
                }
                return FaqList;
            }

            return null;
        }

        public async Task<FaqListODTO> EditFaqList(FaqListIDTO faqListIDTO)
        {
            var faqList = _mapper.Map<FaqList>(faqListIDTO);

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, faqList.Question, faqList.Answer);
            faqList.Question = ym.Content;
            faqList.Answer = ym.Title;

            _context.Entry(faqList).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await GetFaqListById(faqList.FaqPageListId);
        }

        public async Task<FaqListODTO> AddFaqList(FaqListIDTO faqListIDTO)
        {
            var faqList = _mapper.Map<FaqList>(faqListIDTO);

            faqList.FaqPageListId = 0;

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, faqList.Question, faqList.Answer);
            faqList.Question = ym.Content;
            faqList.Answer = ym.Title;

            _context.FaqLists.Add(faqList);
            await SaveContextChangesAsync();
            return await GetFaqListById(faqList.FaqPageListId);
        }

        public async Task<List<FaqListODTO>> AddFaqLists(List<FaqListIDTO> faqListIDTO)
        {
            var faqLists = faqListIDTO.Select(x => _mapper.Map<FaqList>(x)).ToList();

            foreach (var faqList in faqLists)
            {
                var fl = await _context.FaqLists.Where(x => x.Position == faqList.Position && x.FaqTitleId == faqList.FaqTitleId).FirstOrDefaultAsync();
                if (fl != null)
                {
                    YearMonthODTO ym = new YearMonthODTO();
                    ym = await EditDate(null, null, null, null, faqList.Question, faqList.Answer);
                    faqList.Question = ym.Content;
                    faqList.Answer = ym.Title;
                    _context.Entry(fl).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
                else
                {
                    YearMonthODTO ym = new YearMonthODTO();
                    ym = await EditDate(null, null, null, null, faqList.Question, faqList.Answer);
                    faqList.Question = ym.Content;
                    faqList.Answer = ym.Title;
                    faqList.FaqPageListId = 0;
                    _context.FaqLists.Add(faqList);
                }
            }
            await SaveContextChangesAsync();

            return faqLists.Select(x => _mapper.Map<FaqListODTO>(x)).ToList();
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
                   .Include(x => x.Serp)
                   .Include(x => x.Review)
                   where (id == 0 || x.PageId == id)
                   && (languageId == 0 || x.LanguageId == languageId)
                   && (dataTypeId == 0 || x.DataTypeId == dataTypeId)
                   select _mapper.Map<PageODTO>(x);
        }

        public async Task<PageODTO> GetPageById(int id)
        {
            //return await GetPage(id, 0, 0).AsNoTracking().SingleOrDefaultAsync();
            var page = await GetPage(id, 0, 0).AsNoTracking().SingleOrDefaultAsync();

            YearMonthODTO YM = new YearMonthODTO();

            if (page.SelectedPopularArticle != null && page.SelectedPopularArticle != "string")
            {
                page.SelectedPopularArticles = page.SelectedPopularArticle.Split(",").Select(x => Convert.ToInt32(x)).ToArray();
            }
            //[year][month]SerpTitle
            YM = await ChangeDateFormatAdmin(page.SerpTitle, page.SerpDescription, page.Subtitle, page.PageTitle, page.Content, null);
            page.SerpTitle = YM.SerpTitle;
            page.SerpDescription = YM.SerpDescription;
            page.Subtitle = YM.Subtitle;
            page.PageTitle = YM.PageTitle;
            page.Content = YM.Content;
            return page;
        }

        public async Task<List<SymbolODTO>> GetSymoblAndName()
        {
            List<SymbolODTO> list = new List<SymbolODTO>();
            var listOfCrypto = (await _context.Cryptos.ToListAsync()).OrderBy(x => int.Parse(x.rank));

            SymbolODTO s = null;
            foreach (var item in listOfCrypto)
            {
                s = new SymbolODTO();
                s.Symbol = item.symbol;
                s.Name = item.name;
                list.Add(s);
            }

            return list;
        }

        public async Task<List<CryptoODTO>> GetCryptos()
        {
            CryptoODTO Cript = null;
            List<CryptoODTO> Lista = new List<CryptoODTO>();
            string[] CryptoId = new string[] { "bitcoin", "ethereum", "tether", "usd-coin", "binance-usd", "xrp", "cardano", "multi-collateral-dai", "litecoin", "solana", "stasis-euro" };
            foreach (var item in CryptoId)
            {
                string uri = "https://api.coincap.io/v2/assets/" + item;
                using (var client1 = new HttpClient())
                {
                    var header = new AuthenticationHeaderValue("Bearer", "XXXX");
                    client1.DefaultRequestHeaders.Authorization = header;
                    var cr = client1.GetAsync(uri).Result;

                    if (cr.IsSuccessStatusCode)
                    {
                        string a = await cr.Content.ReadAsStringAsync();
                        JObject json = JObject.Parse(a);
                        string jsondata = json["data"].ToString();
                        Cript = JsonConvert.DeserializeObject<CryptoODTO>(jsondata);
                        Lista.Add(Cript);
                    }
                }
            }
            return Lista;
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
                PageTitle = page.PageTitle,
                SerpId = (int)page.SerpId,
                DataTypeId = (int)page.DataTypeId,
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
            var pages = await (from x in _context.Pages
                            .Include(x => x.DataType)
                               where x.LanguageId == langId
                               select new GetPageListODTO
                               {
                                   PageId = x.PageId,
                                   PageTitle = x.PageTitle,
                                   DataTypeId = (int)x.DataTypeId,
                                   DataTypeName = x.DataType.DataTypeName
                               }).OrderByDescending(x => x.PageId).ToListAsync();

            return pages;
        }

        public async Task<GetItemContentODTO> GetItemContent(int? id, int urlId, int langId)
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

                if (route.TableId == 0) throw new Exception("No data available.");
                var pd = await _context.Pages.Where(e => e.ReviewId == route.TableId && route.DataTypeId == REVIEW_TYPEID).FirstOrDefaultAsync();
                var retVal = new GetItemContentODTO
                {
                    PageId = pd.PageId,
                    Content = pd.Content,
                };
                return retVal;
            }
        }

        //TODO /Pages/GetPageContent

        public async Task<PageContentODTO> GetPageContent(int langId, int urlId, int dataTypeId)
        {
            var tableId = await _context.Routes.Where(x => x.LanguageId == langId && x.UrlTableId == urlId && x.DataTypeId == dataTypeId).Select(x => x.TableId).FirstOrDefaultAsync();
            var url = await _context.Routes.Include(x => x.UrlTable).Where(x => x.LanguageId == langId && x.UrlTableId == urlId && x.DataTypeId == dataTypeId).Select(x => x.UrlTable.URL).FirstOrDefaultAsync();

            var academy = await _context.Academies.Include(x => x.UrlTable).Where(x => x.UrlTable.URL == url).FirstOrDefaultAsync();

            if (urlId == 0) return null;
            var page = new PageContentODTO();
            var rData = new GetCampaignBonusODTO();

            switch (dataTypeId)
            {
                case REVIEW_TYPEID:
                    var review = await _context.Review.Include(x => x.Serp).Where(x => x.ReviewId == tableId && dataTypeId == REVIEW_TYPEID && x.IsActive == true).FirstOrDefaultAsync();
                    if (review == null) return null;
                    if (review.ReviewId != 0)
                    {
                        rData = await GetReviewBoxInfo((int)review.ReviewId);
                    }
                    page = new PageContentODTO
                    {
                        ReviewData = review.ReviewId != 0 ? rData : null,
                        SerpId = (int)review.SerpId,
                        SerpDescription = review.Serp.SerpDescription,
                        SerpTitle = review.Serp.SerpTitle,
                        Subtitle = review.Serp.Subtitle,
                        Content = review.ReviewContent,
                        DataTypeId = REVIEW_TYPEID,
                        DataTypeName = await _context.DataTypes.Where(x => x.DataTypeId == REVIEW_TYPEID).Select(x => x.DataTypeName).FirstOrDefaultAsync(),
                    };
                    break;

                case REVIEW_SETTINGS_TYPEID:
                    var reviewSett = await _context.PagesSettings.Include(x => x.Serp).Include(x => x.DataType).Where(x => x.PagesSettingsId == tableId && dataTypeId == REVIEW_SETTINGS_TYPEID).FirstOrDefaultAsync();
                    if (reviewSett == null) return null;
                    page = new PageContentODTO
                    {
                        PageTitle = reviewSett.Title,
                        SerpId = (int)reviewSett.SerpId,
                        SerpDescription = reviewSett.Serp.SerpDescription,
                        SerpTitle = reviewSett.Serp.SerpTitle,
                        Subtitle = reviewSett.Serp.Subtitle,
                        DataTypeId = (int)reviewSett.DataTypeId,
                        DataTypeName = reviewSett.DataType.DataTypeName,
                        Platform = reviewSett.Platform
                    };
                    break;

                case HOME_SETTINGS_TYPEID:
                    var homeSett = await _context.HomeSettings.Include(x => x.Serp).Where(x => x.HomeSettingsId == tableId && dataTypeId == HOME_SETTINGS_TYPEID).FirstOrDefaultAsync();
                    if (homeSett == null) return null;
                    page = new PageContentODTO
                    {
                        PageTitle = homeSett.Title,
                        SerpId = (int)homeSett.SerpId,
                        SerpDescription = homeSett.Serp.SerpDescription,
                        SerpTitle = homeSett.Serp.SerpTitle,
                        Subtitle = homeSett.Serp.Subtitle,
                        DataTypeId = HOME_SETTINGS_TYPEID,
                        DataTypeName = await _context.DataTypes.Where(x => x.DataTypeId == HOME_SETTINGS_TYPEID).Select(x => x.DataTypeName).FirstOrDefaultAsync(),
                        Platform = homeSett.Platform
                    };
                    break;

                case NEWS_SETTINGS_TYPEID:
                    var newsSett = await _context.PagesSettings.Include(x => x.Serp).Include(x => x.DataType).Where(x => x.PagesSettingsId == tableId && dataTypeId == NEWS_SETTINGS_TYPEID).FirstOrDefaultAsync();
                    if (newsSett == null) return null;
                    page = new PageContentODTO
                    {
                        PageTitle = newsSett.Title,
                        SerpId = (int)newsSett.SerpId,
                        SerpDescription = newsSett.Serp.SerpDescription,
                        SerpTitle = newsSett.Serp.SerpTitle,
                        Subtitle = newsSett.Serp.Subtitle,
                        DataTypeId = (int)newsSett.DataTypeId,
                        DataTypeName = newsSett.DataType.DataTypeName,
                        Platform = newsSett.Platform
                    };
                    break;

                case BONUS_SETTINGS_TYPEID:
                    var bonusSett = await _context.PagesSettings.Include(x => x.Serp).Include(x => x.DataType).Where(x => x.PagesSettingsId == tableId && dataTypeId == BONUS_SETTINGS_TYPEID).FirstOrDefaultAsync();
                    if (bonusSett == null) return null;
                    page = new PageContentODTO
                    {
                        PageTitle = bonusSett.Title,
                        SerpId = (int)bonusSett.SerpId,
                        SerpDescription = bonusSett.Serp.SerpDescription,
                        SerpTitle = bonusSett.Serp.SerpTitle,
                        Subtitle = bonusSett.Serp.Subtitle,
                        DataTypeId = (int)bonusSett.DataTypeId,
                        DataTypeName = bonusSett.DataType.DataTypeName,
                        Platform = bonusSett.Platform
                    };
                    break;

                case ACADEMY_SETTINGS_TYPEID:
                    var academySett = await _context.PagesSettings.Include(x => x.Serp).Include(x => x.DataType).Where(x => x.PagesSettingsId == tableId && dataTypeId == ACADEMY_SETTINGS_TYPEID).FirstOrDefaultAsync();
                    if (academySett == null) return null;
                    page = new PageContentODTO
                    {
                        PageTitle = academySett.Title,
                        SerpId = (int)academySett.SerpId,
                        SerpDescription = academySett.Serp.SerpDescription,
                        SerpTitle = academySett.Serp.SerpTitle,
                        Subtitle = academySett.Serp.Subtitle,
                        DataTypeId = (int)academySett.DataTypeId,
                        DataTypeName = academySett.DataType.DataTypeName,
                        Platform = academySett.Platform
                    };
                    break;

                case CASHBACK_BONUS_TYPEID:
                case ACADEMY_TYPEID:
                case GENERAL_TYPEID:
                case ABOUT_TYPEID:
                    var pd1 = await _context.Pages.Include(x => x.Serp).Include(x => x.DataType).Where(x => x.PageId == tableId).FirstOrDefaultAsync();

                    if (pd1 == null) return null;
                    if (pd1.ReviewId != null)
                    {
                        rData = await GetReviewBoxInfo((int)pd1.ReviewId);
                    }
                    page = new PageContentODTO
                    {
                        PageTitle = pd1.PageTitle,
                        Content = pd1.Content,
                        PageId = pd1.PageId,
                        ReviewData = pd1.ReviewId != null ? rData : null,
                        SerpId = (int)pd1.SerpId,
                        SerpDescription = pd1.Serp.SerpDescription,
                        SerpTitle = pd1.Serp.SerpTitle,
                        Subtitle = pd1.Serp.Subtitle,
                        DataTypeId = (int)pd1.DataTypeId,
                        DataTypeName = pd1.DataType.DataTypeName,
                        Platforms = pd1.Platforms,
                        SelectedPopularArtical = pd1.SelectedPopularArticle
                    };
                    if (academy != null)
                    {
                        List<PopularArticlesForPageContentODTO> popularArticles = (from pa in _context.PageArticles.Where(e => e.PageId == page.PageId)
                                                                                   join a in _context.Academies on pa.AcademyId equals a.AcademyId into g
                                                                                   from b in g.DefaultIfEmpty()
                                                                                   select new PopularArticlesForPageContentODTO
                                                                                   {
                                                                                       AcademyId = b.AcademyId,
                                                                                       Title = b.Title,
                                                                                       Image = b.FeaturedImage,
                                                                                       UpdateDate = b.UpdatedDate,
                                                                                       Stars = 4,
                                                                                       Path = b.UrlTable.URL,
                                                                                       Excerpt = b.Excerpt,
                                                                                       Tag = b.Tag
                                                                                   }).Distinct().ToList();

                        YearMonthODTO YM;
                        foreach (var item in popularArticles)
                        {
                            YM = new YearMonthODTO();
                            var LangID = await _context.Academies.Where(x => x.AcademyId == item.AcademyId).Select(x => x.LanguageId).SingleOrDefaultAsync();
                            YM = await ChangeDateFormatFront(null, null, null, null, null, item.Title, LangID);
                            item.Title = YM.Title;
                        }
                        var retVal = new PageContentODTO
                        {
                            Title = academy.Title,
                            PageId = page.PageId,
                            //PopularReviews = topReviews,
                            PopularArticles = popularArticles,
                            Image = academy.FeaturedImage,
                            Tag = academy.Tag,
                            Content = page.Content,
                            SerpId = page.SerpId,
                            Subtitle = page.Subtitle,
                            SerpDescription = page.SerpDescription,
                            SerpTitle = page.SerpTitle,
                            DataTypeId = page.DataTypeId,
                            DataTypeName = page.DataTypeName,
                            Platforms = page.Platforms,
                            SelectedPopularArtical = page.SelectedPopularArtical
                        };

                        YearMonthODTO YM1 = new YearMonthODTO();
                        var LanguageID = await _context.Pages.Where(x => x.PageId == retVal.PageId).Select(x => x.LanguageId).SingleOrDefaultAsync();
                        YM1 = await ChangeDateFormatFront(retVal.SerpTitle, retVal.SerpDescription, retVal.Subtitle, retVal.PageTitle, retVal.Content, retVal.Title, LanguageID);
                        retVal.SerpTitle = YM1.SerpTitle;
                        retVal.SerpDescription = YM1.SerpDescription;
                        retVal.Subtitle = YM1.Subtitle;
                        retVal.Title = YM1.Title;
                        retVal.Content = YM1.Content;
                        retVal.PageTitle = YM1.PageTitle;
                        return retVal;
                    }
                    break;
            }
            YearMonthODTO YM2 = new YearMonthODTO();
            var LanguageID1 = await _context.Pages.Where(x => x.PageId == page.PageId).Select(x => x.LanguageId).SingleOrDefaultAsync();
            YM2 = await ChangeDateFormatFront(page.SerpTitle, page.SerpDescription, page.Subtitle, page.PageTitle, page.Content, page.Title, LanguageID1);
            page.SerpTitle = YM2.SerpTitle;
            page.SerpDescription = YM2.SerpDescription;
            page.Subtitle = YM2.Subtitle;
            page.Title = YM2.Title;
            page.Content = YM2.Content;
            page.PageTitle = YM2.PageTitle;
            return page;
        }

        public async Task<CryptoODTO> GetCryptoBySymbol(string symbol)
        {
            var Crypto = await _context.Cryptos.Where(x => x.symbol == symbol).SingleOrDefaultAsync();
            return _mapper.Map<CryptoODTO>(Crypto);
        }

        public async Task<List<PageODTO>> GetPageByLanguageId(int id)
        {
            var page = await GetPage(0, id, 0).ToListAsync();
            foreach (var item in page)
            {
                YearMonthODTO YM = new YearMonthODTO();

                if (item.SelectedPopularArticle != null && item.SelectedPopularArticle != "string")
                {
                    item.SelectedPopularArticles = item.SelectedPopularArticle.Split(",").Select(x => Convert.ToInt32(x)).ToArray();
                }
                //[year][month]SerpTitle
                YM = await ChangeDateFormatAdmin(item.SerpTitle, item.SerpDescription, item.Subtitle, item.PageTitle, item.Content, null);
                item.SerpTitle = YM.SerpTitle;
                item.SerpDescription = YM.SerpDescription;
                item.Subtitle = YM.Subtitle;
                item.PageTitle = YM.PageTitle;
                item.Content = YM.Content;
            }

            return page;
        }

        public async Task<List<PageODTO>> GetPageByDataTypeId(int id)
        {
            return await GetPage(0, 0, id).ToListAsync();
        }

        public async Task<PageODTO> EditPageContent(PutContentIDTO contentIDTO)
        {
            var page = await _context.Pages.Where(x => x.PageId == contentIDTO.Id).FirstOrDefaultAsync();
            YearMonthODTO YM = new YearMonthODTO();
            YM = await EditDate(null, null, null, null, contentIDTO.Content, null);
            page.Content = YM.Content;
            _context.Entry(page).State = EntityState.Modified;
            await SaveContextChangesAsync();
            return await GetPageById(page.PageId);
        }

        public async Task<PageODTO> EditPage(PageIDTO pageIDTO)
        {
            var page = _mapper.Map<Entities.P2P.MainData.Page>(pageIDTO);
            page.Platforms = pageIDTO.Platforms;
            page.SelectedPopularArticle = (page.SelectedPopularArticle == null || page.SelectedPopularArticle == "") ? null : page.SelectedPopularArticle;

            YearMonthODTO YM = new YearMonthODTO();
            YM = await EditDate(null, null, null, page.PageTitle, page.Content, null);
            page.PageTitle = YM.PageTitle;
            page.Content = YM.Content;
            _context.Entry(page).State = EntityState.Modified;
            await SaveContextChangesAsync();

            #region SelectedPopularArticlesCheck

            var lista = await _context.PageArticles.Where(x => x.PageId == page.PageId).ToListAsync();
            if (page.SelectedPopularArticle != null)
            {
                PageArticles pa;
                var popularArticle = page.SelectedPopularArticle.Split(",").Select(x => Convert.ToInt32(x)).ToArray();

                foreach (var item in popularArticle)
                {
                    var selectedPopArt = await _context.PageArticles.Where(x => x.PageId == page.PageId && x.AcademyId == item).FirstOrDefaultAsync();
                    pa = new PageArticles();
                    pa.PageId = page.PageId;
                    pa.AcademyId = item;
                    if (selectedPopArt == null)
                    {
                        _context.PageArticles.Add(pa);
                        await SaveContextChangesAsync();
                    }
                }
                if (lista != null)
                {
                    foreach (var item1 in lista)
                    {
                        if (!popularArticle.Contains(item1.AcademyId))
                        {
                            _context.PageArticles.Remove(item1);
                            await SaveContextChangesAsync();
                        }
                    }
                }
            }

            if ((page.SelectedPopularArticle == null || page.SelectedPopularArticle == "") && lista != null)
            {
                foreach (var item2 in lista)
                {
                    _context.PageArticles.Remove(item2);
                    await SaveContextChangesAsync();
                }
            }

            #endregion SelectedPopularArticlesCheck

            return await GetPageById(page.PageId);
        }

        public async Task<List<CryptoODTO>> UpdateCrypto()
        {
            var Cryp = await GetCryptos();
            List<CryptoODTO> ReturnList = new List<CryptoODTO>();
            var CryptoList = (await _context.Cryptos.ToListAsync()).OrderBy(x => int.Parse(x.rank));
            foreach (var item in CryptoList)
            {
                foreach (var c in Cryp)
                {
                    if (item.symbol == c.symbol)
                    {
                        item.rank = c.rank;
                        item.supply = c.supply;
                        item.maxSupply = c.maxSupply;
                        item.marketCapUsd = c.marketCapUsd;
                        item.volumeUsd24Hr = c.volumeUsd24Hr;
                        item.priceUsd = c.priceUsd;
                        item.changePercent24Hr = c.changePercent24Hr;
                        item.vwap24Hr = c.vwap24Hr;
                        item.explorer = c.explorer;
                        _context.Entry(item).State = EntityState.Modified;
                        await SaveContextChangesAsync();
                        ReturnList.Add(_mapper.Map<CryptoODTO>(item));
                    }
                }
            }
            return ReturnList;
        }

        public async Task<PageODTO> AddPage(PageIDTO pageIDTO)
        {
            var page = _mapper.Map<Entities.P2P.MainData.Page>(pageIDTO);
            page.PageId = 0;
            page.SelectedPopularArticle = page.SelectedPopularArticle == null || page.SelectedPopularArticle == "" ? null : page.SelectedPopularArticle;

            YearMonthODTO YM = new YearMonthODTO();
            YM = await EditDate(null, null, null, page.PageTitle, page.Content, null);
            page.PageTitle = YM.PageTitle;
            page.Content = YM.Content;

            _context.Pages.Add(page);
            await SaveContextChangesAsync();

            return await GetPageById(page.PageId);
        }

        public async Task<PageODTO> DeletePage(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            if (page == null) return null;

            var faqTitles = await _context.FaqTitles.Where(x => x.PageId == page.PageId).ToListAsync();
            var pageArticles = await _context.PageArticles.Where(x => x.PageId == page.PageId).ToListAsync();
            var routes = await _context.Routes.Where(x => x.TableId == page.PageId && (x.DataTypeId == CASHBACK_BONUS_TYPEID || x.DataTypeId == ACADEMY_TYPEID || x.DataTypeId == GENERAL_TYPEID || x.DataTypeId == ABOUT_TYPEID)).ToListAsync();

            foreach (var item in routes)
            {
                _context.Routes.Remove(item);
                await SaveContextChangesAsync();
            }
            foreach (var item in routes)
            {
                var url = await _context.UrlTables.Where(x => x.UrlTableId == item.UrlTableId).FirstOrDefaultAsync();
                url.TableId = null;
                _context.Entry(url).State = EntityState.Modified;
                await SaveContextChangesAsync();
            }

            foreach (var item in pageArticles)
            {
                _context.PageArticles.Remove(item);
                await SaveContextChangesAsync();
            }
            foreach (var item in faqTitles)
            {
                var x = await _context.FaqLists.Where(x => x.FaqTitleId == item.FaqTitleId).ToListAsync();
                foreach (var item2 in x)
                {
                    _context.FaqLists.Remove(item2);
                    await SaveContextChangesAsync();
                }
            }
            foreach (var item in faqTitles)
            {
                _context.FaqTitles.Remove(item);
                await SaveContextChangesAsync();
            }

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
                   .Include(z => z.Serp)
                   .Include(z => z.Language)
                   .Include(x => x.Rev_FacebookUrl)
                   .Include(x => x.Rev_InstagramUrl)
                   .Include(x => x.Rev_LinkedInUrl)
                   .Include(x => x.Rev_TwitterUrl)
                   .Include(x => x.Rev_YoutubeUrl)
                   .Include(x => x.Rev_ReportLink)
                   where ((id == 0 || x.ReviewId == id))
                   select _mapper.Map<ReviewODTO>(x);
        }

        public async Task<ReviewODTO> GetReviewById(int id)
        {
            var review = await GetReview(id).AsNoTracking().FirstOrDefaultAsync();

            YearMonthODTO ym = new YearMonthODTO();
            ym = await ChangeDateFormatAdmin(review.SerpTitle, review.SerpDescription, review.Subtitle, null, review.ReviewContent, null);
            review.SerpTitle = ym.SerpTitle;
            review.SerpDescription = ym.SerpDescription;
            review.Subtitle = ym.Subtitle;
            review.ReviewContent = ym.Content;

            return review;
        }

        public async Task<ReviewODTO> GetReviewFull(int id)
        {
            var gu = await _context.UrlLanguages.Where(x => x.TableID == id).Select(x => x.GUID).ToListAsync();

            return await (from x in _context.Review
                   .Include(z => z.Serp)
                   .Include(z => z.Language)
                   .Include(x => x.Rev_FacebookUrl)
                   .Include(x => x.Rev_InstagramUrl)
                   .Include(x => x.Rev_LinkedInUrl)
                   .Include(x => x.Rev_TwitterUrl)
                   .Include(x => x.Rev_YoutubeUrl)
                   .Include(x => x.Rev_ReportLink)
                          where (id == 0 || x.ReviewId == id)
                          select new ReviewODTO
                          {
                              ReviewId = x.ReviewId,
                              SerpId = x.SerpId,
                              SerpDescription = x.Serp.SerpDescription,
                              Subtitle = x.Serp.Subtitle,
                              LanguageId = x.LanguageId,
                              Languagename = x.Language.LanguageName,
                              ReportLink = x.ReportLink,
                              ReportUrlName = x.Rev_ReportLink.URL,
                              Name = x.Name,
                              Logo = x.Logo,
                              Interest = x.Interest,
                              SecuredBy = x.SecuredBy,
                              SecuredByCheck = x.SecuredByCheck,
                              NotSecured = x.NotSecured,
                              Bonus = x.Bonus,
                              CustomMessage = x.CustomMessage,
                              CompareButton = x.CompareButton,
                              RiskReturn = x.RiskReturn,
                              Usability = x.Usability,
                              Liquidity = x.Liquidity,
                              Support = x.Support,
                              Features = x.Features,
                              AutoInvest = x.AutoInvest,
                              SecondaryMarket = x.SecondaryMarket,
                              Promotion = x.Promotion,
                              MinInvestment = x.MinInvestment,
                              DiversificationOtherCurrency = x.DiversificationOtherCurrency,
                              Countries = x.Countries,
                              LoanOriginators = x.LoanOriginators,
                              LoanType = x.LoanType,
                              InterestRange = x.InterestRange,
                              MinLoanPerion = x.MaxLoanPerion,
                              MaxLoanPerion = x.MaxLoanPerion,
                              OperatingSince = x.OperatingSince,
                              Earnings = x.Earnings,
                              TotalLoanValue = x.TotalLoanValue,
                              NumberOfInvestors = x.NumberOfInvestors,
                              InvestorsLoss = x.InvestorsLoss,
                              PortfolioSize = x.PortfolioSize,
                              FinancialReport = x.FinancialReport,
                              StatisticsOtherCurrency = x.StatisticsOtherCurrency,
                              BuybackGuarantee = x.BuybackGuarantee,
                              PersonalGuarantee = x.PersonalGuarantee,
                              Mortage = x.Mortage,
                              Collateral = x.Collateral,
                              NoProtection = x.NoProtection,
                              CryptoAssets = x.CryptoAssets,
                              LegalName = x.LegalName,
                              Address = x.Address,
                              Phone = x.Phone,
                              Email = x.Email,
                              LiveChat = x.LiveChat,
                              OpeningHours = x.OpeningHours,
                              TableOfContents = x.TableOfContents,
                              CashbackBonus = x.CashbackBonus,
                              DiversificationMinInvest = x.DiversificationMinInvest,
                              ProtectionScheme = x.ProtectionScheme,
                              ReviewContent = x.ReviewContent,
                              StatisticsCurrency = x.StatisticsCurrency,
                              Cryptoloan = x.Cryptoloan,
                              UpdatedDate = x.UpdatedDate,
                              RatingCalculated = x.RatingCalculated,
                              NewPlatform = x.NewPlatform,
                              Recommended = x.Recommended,
                              OfficeAddress = x.OfficeAddress,
                              RiskAndReturn = x.RiskAndReturn,
                              Availability = x.Availability,
                              Count = x.Count,
                              IsActive = x.IsActive,
                              UO = (from y in _context.UrlLanguages
                                    where (gu.Contains(y.GUID))
                                    select _mapper.Map<UrlLanguagesODTO>(y)).ToList()
                          }).SingleOrDefaultAsync();
        }

        public async Task<GetReviewsByRouteODTO> GetReviewsByRoute(string url, int langId)
        {
            int UrlReviewId = await (from x in _context.Routes
                                     .Include(x => x.UrlTable)
                                     where (x.UrlTable.URL == url)
                                     && (x.LanguageId == langId)
                                     select x.TableId).FirstOrDefaultAsync();
            var review = await _context.Review.Include(x => x.Serp).Include(x => x.Rev_ReportLink).Where(x => x.IsActive == true && x.ReviewId == UrlReviewId).FirstOrDefaultAsync();
            //TITLE
            // set review.serp.serptitle [year] from [2022] to 2022
            if (review != null)
            {
                YearMonthODTO ym = new YearMonthODTO();
                ym = await ChangeDateFormatFront(review.Serp.SerpTitle, review.Serp.SerpDescription, review.Serp.Subtitle, null, review.ReviewContent, null, review.LanguageId);

                review.ReviewContent = ym.Content;
                review.Serp.SerpDescription = ym.SerpDescription;
                review.Serp.SerpTitle = ym.SerpTitle;
                review.Serp.Subtitle = ym.Subtitle;
            }
            var newsfeed = await (from x in _context.NewsFeeds
                                  .Include(x => x.UrlTable)
                                  .Include(x => x.Language)
                                  where (x.ReviewId == review.ReviewId)
                                  orderby x.CreatedDate descending
                                  select _mapper.Map<NewsFeedODTO>(x)).Take(4).ToListAsync();

            var ReviewBoxOne = new ReviewBoxOneODTO()
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
            };
            var ReviewBoxTwo = new ReviewBoxTwoODTO()
            {
                Highlights = _context.ReviewAttributes.Include(x => x.DataType).Where(x => x.ReviewId == UrlReviewId && x.DataTypeId == HIGHLIGHT_ATTR_TYPEID).Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList(),
                Ratings = new decimal?[] { review.RiskReturn, review.Usability, review.Liquidity, review.Support }
            };

            var ReviewBoxThree = new ReviewBoxThreeODTO()
            {
                BuybackGuarantee = review.BuybackGuarantee,
                AutoInvest = review.AutoInvest,
                Secondarymarket = review.SecondaryMarket,
                Cashback = review.CashbackBonus,
                Promotion = review.Promotion
            };
            var reviewBoxFour = new ReviewBoxFourODTO()
            {
                MinInvestment = review.DiversificationMinInvest,
                Country = review.Countries,
                LoanOriginators = review.LoanOriginators,
                LoanType = review.LoanType,
                LoanPeriod = string.Format("{0} - {1}", review.MinLoanPerion, review.MaxLoanPerion),
                Interest = review.InterestRange,
                Currency = review.StatisticsCurrency
            };
            var reviewBoxFive =
            new ReviewBoxFiveODTO()
            {
                Benefits = _context.ReviewAttributes.Include(x => x.DataType).Where(x => x.ReviewId == UrlReviewId && x.DataTypeId == BENEFIT_ATTR_TYPEID).Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList(),
                Disadvantages = _context.ReviewAttributes.Include(x => x.DataType).Where(x => x.ReviewId == UrlReviewId && x.DataTypeId == DISSADVANTAGE_ATTR_TYPEID).Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList()
            };
            var statistics = new StatisticsODTO()
            {
                OperatingSince = review.OperatingSince,
                Investors = review.NumberOfInvestors,
                InvestorsEarnings = review.Earnings,
                AveragePortfolio = review.PortfolioSize,
                TotalInvested = review.TotalLoanValue,
                FinancialReport = review.FinancialReport,
                InvestorsLoss = review.InvestorsLoss,
                StatisticsOtherCurrency = review.StatisticsOtherCurrency,
                ReportLink = (review.ReportLink != null) ? review.ReportLink : null,
                ReportLinkUrl = (review.ReportLink != null) ? review.Rev_ReportLink.URL : "",
                StatisticsCurrency = review.StatisticsCurrency
            };
            var CompanyInfo = new CompanyInfoODTO()
            {
                Name = review.LegalName,
                Address = review.Address,
                Phone = review.Phone,
                Email = review.Email,
                LiveChat = review.LiveChat,
                OpeningHours = review.OpeningHours,
                SocialMedia = new int?[] { review.FacebookUrl, review.TwitterUrl, review.LinkedInUrl, review.YoutubeUrl, review.InstagramUrl },
            };
            var data = new GetReviewsByRouteODTO
            {
                ReviewId = review.ReviewId,
                Name = review.Name,
                UpdatedDate = review.UpdatedDate,
                Availability = review.Availability,
                SerpId = review.SerpId,
                SerpDescription = review.Serp.SerpDescription,
                SerpTitle = review.Serp.SerpTitle,
                Subtitle = review.Serp.Subtitle,
                RiskReturn = review.RiskReturn,
                Address = review.OfficeAddress,
                Content = review.ReviewContent,
                Count = (review.Count != null) ? review.Count : 0,
                ReviewBoxOne = ReviewBoxOne,
                ReviewBoxTwo = ReviewBoxTwo,
                ReviewBoxThree = ReviewBoxThree,
                ReviewBoxFour = reviewBoxFour,
                ReviewBoxFive = reviewBoxFive,
                Statistics = statistics,
                CompanyInfo = CompanyInfo,
                NewsFeeds = newsfeed
            };

            return data;
        }

        public async Task<List<ReviewContentDropdownODTO>> GetListOfReviews()
        {
            List<ReviewContentDropdownODTO> reviews = await ListOfReviews();
            return reviews;
        }

        public async Task<GetCampaignBonusODTO> GetReviewBoxInfo(int? id)
        {
            var data = await (from x in _context.CashBacks
                              join r in _context.Review on x.ReviewId equals r.ReviewId into a
                              from d in a.DefaultIfEmpty()
                              where id != null && d.ReviewId == id && d.IsActive == true
                              select new GetCampaignBonusODTO
                              {
                                  CashBackId = x.CashBackId,
                                  ReviewId = d.ReviewId,
                                  Name = d.Name,
                                  Logo = d.Logo,
                                  CashbackCta = x.CashBack_ca,
                                  Stars = (decimal)d.RatingCalculated,
                                  //(decimal)(((d.RiskAndReturn != null ? d.RiskAndReturn : 0) + (d.Usability != null ? d.Usability : 0) +
                                  //(d.Liquidity != null ? d.Liquidity : 0) + (d.Support != null ? d.Support : 0)) / 4),
                                  ExternalLinkKey = d.Name.ToLower(),
                                  ReviewUrlId = _context.Routes.FirstOrDefault(e => e.DataTypeId == REVIEW_TYPEID && e.TableId == d.ReviewId).UrlTableId,
                                  Terms = x.CashBack_terms,
                                  ReviewBoxThree = new ReviewBoxThreeODTO
                                  {
                                      BuybackGuarantee = d.BuybackGuarantee,
                                      AutoInvest = d.AutoInvest,
                                      Secondarymarket = d.SecondaryMarket,
                                      Cashback = d.CashbackBonus,
                                      Promotion = d.Promotion
                                  },
                                  ReviewBoxFour = new ReviewBoxFourODTO
                                  {
                                      MinInvestment = d.DiversificationMinInvest,
                                      Country = d.Countries,
                                      LoanOriginators = d.LoanOriginators,
                                      LoanType = d.LoanType,
                                      LoanPeriod = string.Format("{0} - {1}", d.MinLoanPerion, d.MaxLoanPerion),
                                      Interest = d.InterestRange,
                                      Currency = d.StatisticsCurrency
                                  },
                                  ReviewBoxFive = new ReviewBoxFiveODTO
                                  {
                                      Benefits = _context.ReviewAttributes.Include(x => x.DataType).Where(x => x.ReviewId == d.ReviewId && x.DataTypeId == BENEFIT_ATTR_TYPEID).Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList(),
                                      Disadvantages = _context.ReviewAttributes.Include(x => x.DataType).Where(x => x.ReviewId == d.ReviewId && x.DataTypeId == DISSADVANTAGE_ATTR_TYPEID).Select(x => _mapper.Map<ReviewAttributeODTO>(x)).ToList()
                                  }
                              }).FirstOrDefaultAsync();
            return data;
        }

        public async Task AddCount(string name)
        {
            var reviewCount = await _context.Review.Where(x => x.Name.ToLower() == name.ToLower() && x.IsActive == true).ToListAsync();

            foreach (var item in reviewCount)
            {
                if (item != null)
                {
                    if (item.Count != null)
                    {
                        item.Count += 1;
                    }
                    else
                    {
                        item.Count = 1;
                    }
                    _context.Entry(item).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
            }
        }

        public async Task<List<ReviewContentDropdownODTO>> GetListOfReviewsByLang(int langId)
        {
            List<ReviewContentDropdownODTO> reviews = await (from x in _context.Review
                                                             where x.LanguageId == langId && x.IsActive == true
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
            var ReviewRoute = await (from x in _context.Review
                                     join r in _context.Routes.Where(x => x.DataTypeId == REVIEW_TYPEID) on x.ReviewId equals r.TableId into c
                                     from a in c.DefaultIfEmpty()
                                     where (a.DataTypeId == REVIEW_TYPEID && x.LanguageId == langId && x.IsActive == true)
                                     select new GetParentReviewODTO
                                     {
                                         ReviewId = x.ReviewId,
                                         Stars = x.RatingCalculated,
                                         Logo = x.Logo,
                                         Name = x.Name,
                                         LinkTo = a.UrlTableId,
                                         LinkToUrl = a.UrlTable.URL,
                                         NewPlatform = x.NewPlatform,
                                         Interest = x.Interest,
                                         SecuredBy = x.SecuredBy,
                                         Count = (x.Count != null) ? x.Count : 0,
                                         Guarantee = (bool)x.BuybackGuarantee ? "buyback guarantee" : (bool)x.PersonalGuarantee ? "personal guarantee " : (bool)x.Mortage ? "mortgage" : (bool)x.Collateral ? "collateral" :
                                                     (bool)x.NoProtection ? "not secured" : (bool)x.CryptoAssets ? "cryptoassets" : "",
                                         IsSecured = !x.NotSecured,
                                         ExternalLinkKey = x.Name.ToLower(),
                                         CustomMessage = x.CustomMessage,
                                         Recommended = x.Recommended,
                                         CompareButton = (bool)x.CompareButton ? true : false,
                                     }).OrderBy(x => x.ReviewId).ToListAsync();
            YearMonthODTO ym;
            foreach (var item in ReviewRoute)
            {
                ym = new YearMonthODTO();
                ym = await ChangeDateFormatFront(null, null, null, null, item.CustomMessage, null, langId);

                if (ym != null)
                {
                    item.CustomMessage = ym.Content;//Custom message will be delivered to function as Content
                }

            }
            return ReviewRoute;
        }

        public async Task<ReviewODTO> EditReviewContent(PutContentIDTO contentIDTO)
        {
            var review = await _context.Review.Where(x => x.ReviewId == contentIDTO.Id).SingleOrDefaultAsync();
            YearMonthODTO ym = new YearMonthODTO();

            ym = await EditDate(null, null, null, null, contentIDTO.Content, null);
            contentIDTO.Content = ym.Content;
            review.ReviewContent = ym.Content;//Parameter placed in variable Title inside the function EditDate();
            _context.Entry(review).State = EntityState.Modified;
            await SaveContextChangesAsync();

            review.ReviewContent = contentIDTO.Content;
            _context.Entry(review).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await GetReviewById(review.ReviewId);
        }

        public async Task<ReviewODTO> EditReview(ReviewIDTO reviewIDTO)
        {
            var review = _mapper.Map<Review>(reviewIDTO);
            if (reviewIDTO.LanguageId != ENG_LANG)
            {
                review.SerpId = review.SerpId != 0 ? review.SerpId : null;
                review.SecuredBy = review.SecuredBy != 0 ? review.SecuredBy : null;
                review.MinInvestment = review.MinInvestment != 0 ? review.MinInvestment : null;
                review.Countries = review.Countries != 0 ? review.Countries : null;
                review.LoanOriginators = review.LoanOriginators != 0 ? review.LoanOriginators : null;
                review.MinLoanPerion = review.MinLoanPerion != 0 ? review.MinLoanPerion : null;
                review.MaxLoanPerion = review.MaxLoanPerion != 0 ? review.MaxLoanPerion : null;
                review.OperatingSince = review.OperatingSince != 0 ? review.OperatingSince : null;
                review.LoanType = review.LoanType != 0 ? review.LoanType : null;
                review.PortfolioSize = review.PortfolioSize != 0 ? review.PortfolioSize : null;
                review.Availability = review.Availability != 0 ? review.Availability : null;
                review.Count = review.Count != 0 ? review.Count : null;
                review.Earnings = review.Earnings != 0 ? review.Earnings : null;
                review.Cryptoloan = review.Cryptoloan != 0 ? review.Cryptoloan : null;
                review.DiversificationMinInvest = review.DiversificationMinInvest != 0 ? review.DiversificationMinInvest : null;
                review.TotalLoanValue = review.TotalLoanValue != 0 ? review.TotalLoanValue : null;
                review.NumberOfInvestors = review.NumberOfInvestors != 0 ? review.NumberOfInvestors : null;
                review.InvestorsLoss = review.InvestorsLoss != 0 ? review.InvestorsLoss : null;
                review.RiskReturn = review.RiskReturn != 0 ? review.RiskReturn : null;
                review.Usability = review.Usability != 0 ? review.Usability : null;
                review.Liquidity = review.Liquidity != 0 ? review.Liquidity : null;
                review.Support = review.Support != 0 ? review.Support : null;
                review.Interest = review.Interest != 0 ? review.Interest : null;
                review.RiskReturn = review.RiskReturn != 0 ? review.RiskReturn : null;
                review.RatingCalculated = review.RatingCalculated != 0 ? review.RatingCalculated : null;
                review.StatisticsCurrency = review.StatisticsCurrency != "string" ? review.StatisticsCurrency : null;
                review.ReportLink = review.ReportLink != 0 ? review.ReportLink : null;
                review.UpdatedDate = DateTime.Now;
                review.IsActive = review.IsActive != null ? review.IsActive : null;
                _context.Entry(review).State = EntityState.Modified;
                await SaveContextChangesAsync();

                if (reviewIDTO.ReportLinkURL != null)
                {
                    var urlName = await _context.UrlTables.Where(x => x.URL.ToLower() == reviewIDTO.ReportLinkURL.ToLower()).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                    if (urlName != 0 && review.ReportLink == 0)
                    {
                        review.ReportLink = urlName;
                    }
                    else if (review.ReportLink == 0)
                    {
                        review.ReportLink = null;
                    }
                    _context.Entry(review).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                    if (review.ReportLink != null)
                    {
                        return await GetReviewById(review.ReviewId);
                    }
                    else
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = REVIEW_TYPEID,
                            TableId = review.ReviewId,
                            URL = reviewIDTO.ReportLinkURL
                        };
                        _context.UrlTables.Add(url);
                        await SaveContextChangesAsync();
                        review.ReportLink = url.UrlTableId;
                        _context.Entry(review).State = EntityState.Modified;
                        await SaveContextChangesAsync();
                        return await GetReviewById(review.ReviewId);
                    }
                }

                return await GetReviewById(review.ReviewId);
            }
            return null;
        }

        public async Task<List<ReviewODTO>> EditParentReview(ReviewIDTO reviewIDTO)
        {
            var review = _mapper.Map<Review>(reviewIDTO);
            if (reviewIDTO.LanguageId == ENG_LANG)
            {
                review.SerpId = review.SerpId != 0 ? review.SerpId : null;
                review.SecuredBy = review.SecuredBy != 0 ? review.SecuredBy : null;
                review.MinInvestment = review.MinInvestment != 0 ? review.MinInvestment : null;
                review.Countries = review.Countries != 0 ? review.Countries : null;
                review.LoanOriginators = review.LoanOriginators != 0 ? review.LoanOriginators : null;
                review.MinLoanPerion = review.MinLoanPerion != 0 ? review.MinLoanPerion : null;
                review.MaxLoanPerion = review.MaxLoanPerion != 0 ? review.MaxLoanPerion : null;
                review.OperatingSince = review.OperatingSince != 0 ? review.OperatingSince : null;
                review.LoanType = review.LoanType != 0 ? review.LoanType : null;
                review.PortfolioSize = review.PortfolioSize != 0 ? review.PortfolioSize : null;
                review.Availability = review.Availability != 0 ? review.Availability : null;
                review.Count = review.Count != 0 ? review.Count : null;
                review.Earnings = review.Earnings != 0 ? review.Earnings : null;
                review.Cryptoloan = review.Cryptoloan != 0 ? review.Cryptoloan : null;
                review.DiversificationMinInvest = review.DiversificationMinInvest != 0 ? review.DiversificationMinInvest : null;
                review.TotalLoanValue = review.TotalLoanValue != 0 ? review.TotalLoanValue : null;
                review.NumberOfInvestors = review.NumberOfInvestors != 0 ? review.NumberOfInvestors : null;
                review.InvestorsLoss = review.InvestorsLoss != null ? review.InvestorsLoss : null;
                review.RiskReturn = review.RiskReturn != 0 ? review.RiskReturn : 0;
                review.Usability = review.Usability != 0 ? review.Usability : 0;
                review.Liquidity = review.Liquidity != 0 ? review.Liquidity : 0;
                review.Support = review.Support != 0 ? review.Support : 0;
                review.Interest = review.Interest != 0 ? review.Interest : null;
                review.RiskAndReturn = review.RiskAndReturn != 0 ? review.RiskAndReturn : null;
                review.RatingCalculated = review.RatingCalculated != 0 ? review.RatingCalculated : null;
                review.StatisticsCurrency = review.StatisticsCurrency != "string" ? review.StatisticsCurrency : null;
                review.ReportLink = review.ReportLink != 0 ? review.ReportLink : null;
                review.UpdatedDate = DateTime.Now;
                review.IsActive = review.IsActive != null ? review.IsActive : null;

                _context.Entry(review).State = EntityState.Modified;
                await SaveContextChangesAsync();

                if (reviewIDTO.ReportLinkURL != null)
                {
                    var urlName = await _context.UrlTables.Where(x => x.URL.ToLower() == reviewIDTO.ReportLinkURL.ToLower()).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                    if (urlName != 0 && review.ReportLink == 0)
                    {
                        review.ReportLink = urlName;
                    }
                    else if (review.ReportLink == 0)
                    {
                        review.ReportLink = null;
                    }

                    _context.Entry(review).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                    if (review.ReportLink != null)
                    {
                        return null; //await GetReviewById(review.ReviewId);
                    }
                    else
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = REVIEW_TYPEID,
                            TableId = review.ReviewId,
                            URL = reviewIDTO.ReportLinkURL
                        };
                        _context.UrlTables.Add(url);
                        await SaveContextChangesAsync();
                        review.ReportLink = url.UrlTableId;
                        _context.Entry(review).State = EntityState.Modified;
                        await SaveContextChangesAsync();
                    }
                }
                var childReviews = await _context.Review.Where(x => (x.Name == reviewIDTO.Name || x.LegalName == reviewIDTO.LegalName) && x.LanguageId != ENG_LANG).ToListAsync();
                foreach (var item in childReviews)
                {
                    item.ReviewId = item.ReviewId;
                    item.SerpId = item.SerpId;
                    item.LanguageId = item.LanguageId;
                    item.Name = item.Name;
                    item.Logo = review.Logo;
                    item.Bonus = item.Bonus;
                    item.CustomMessage = item.CustomMessage;
                    item.CompareButton = item.CompareButton;
                    item.NewPlatform = item.NewPlatform;
                    item.Recommended = item.Recommended;
                    item.ReviewContent = item.ReviewContent;

                    item.Interest = review.Interest;
                    item.SecuredBy = review.SecuredBy;
                    item.SecuredByCheck = review.SecuredByCheck;
                    item.NotSecured = review.NotSecured;
                    item.RiskReturn = review.RiskReturn;
                    item.Usability = review.Usability;
                    item.Liquidity = review.Liquidity;
                    item.Support = review.Support;
                    item.Features = review.Features;
                    item.AutoInvest = review.AutoInvest;
                    item.SecondaryMarket = review.SecondaryMarket;
                    item.Promotion = review.Promotion;
                    item.MinInvestment = review.MinInvestment;
                    item.DiversificationMinInvest = review.DiversificationMinInvest;
                    item.DiversificationOtherCurrency = review.DiversificationOtherCurrency;
                    item.Countries = review.Countries;
                    item.LoanOriginators = review.LoanOriginators;
                    item.LoanType = review.LoanType;
                    item.InterestRange = review.InterestRange;
                    item.MinLoanPerion = review.MinLoanPerion;
                    item.MaxLoanPerion = review.MaxLoanPerion;
                    item.OperatingSince = review.OperatingSince;
                    item.Earnings = review.Earnings;
                    item.TotalLoanValue = review.TotalLoanValue;
                    item.NumberOfInvestors = review.NumberOfInvestors;
                    item.InvestorsLoss = review.InvestorsLoss;
                    item.PortfolioSize = review.PortfolioSize;
                    //item.FinancialReport = review.FinancialReport;
                    item.StatisticsCurrency = review.StatisticsCurrency;
                    item.BuybackGuarantee = review.BuybackGuarantee;
                    item.PersonalGuarantee = review.PersonalGuarantee;
                    item.Mortage = review.Mortage;
                    item.Collateral = review.Collateral;
                    item.NoProtection = review.NoProtection;
                    item.CryptoAssets = review.CryptoAssets;
                    item.LegalName = review.LegalName;
                    item.Address = review.Address;
                    item.Phone = review.Phone;
                    item.Email = review.Email;
                    item.LiveChat = review.LiveChat;
                    item.OpeningHours = review.OpeningHours;
                    item.TableOfContents = review.TableOfContents;
                    item.CashbackBonus = review.CashbackBonus;
                    item.ProtectionScheme = review.ProtectionScheme;
                    item.StatisticsCurrency = review.StatisticsCurrency;
                    item.Cryptoloan = review.Cryptoloan;
                    item.UpdatedDate = DateTime.Now;
                    item.RatingCalculated = review.RatingCalculated;
                    item.OfficeAddress = review.OfficeAddress;
                    item.RiskAndReturn = review.RiskAndReturn;
                    item.Availability = review.Availability;
                    item.Count = review.Count;
                    review.IsActive = review.IsActive != null ? review.IsActive : null;

                    _context.Entry(item).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
                var ParentID = review.ReviewId;
                var ChildsID = new List<int>();
                var ParentChild = new List<ReviewODTO>();
                foreach (var item in childReviews)
                {
                    ChildsID.Add(item.ReviewId);
                }
                ChildsID.Add(ParentID);
                foreach (var item in ChildsID)
                {
                    var reviews = await _context.Review.Where(x => x.ReviewId == item).FirstOrDefaultAsync();
                    ParentChild.Add(_mapper.Map<ReviewODTO>(reviews));
                }

                return ParentChild;
            }
            return null;
        }

        public async Task<ReviewODTO> AddReview(ReviewIDTO reviewIDTO)
        {
            try
            {
                var review = _mapper.Map<Review>(reviewIDTO);
                review.ReviewId = 0;
                review.SerpId = review.SerpId != 0 ? review.SerpId : null;
                review.SecuredBy = review.SecuredBy != 0 ? review.SecuredBy : null;
                review.MinInvestment = review.MinInvestment != 0 ? review.MinInvestment : null;
                review.Countries = review.Countries != 0 ? review.Countries : null;
                review.LoanOriginators = review.LoanOriginators != 0 ? review.LoanOriginators : null;
                review.MinLoanPerion = review.MinLoanPerion != 0 ? review.MinLoanPerion : null;
                review.MaxLoanPerion = review.MaxLoanPerion != 0 ? review.MaxLoanPerion : null;
                review.OperatingSince = review.OperatingSince != 0 ? review.OperatingSince : null;
                review.LoanType = review.LoanType != 0 ? review.LoanType : null;
                review.PortfolioSize = review.PortfolioSize != 0 ? review.PortfolioSize : null;
                review.Availability = review.Availability != 0 ? review.Availability : null;
                var NewReview = await _context.Review.Where(x => x.Name.ToLower() == review.Name.ToLower() && x.LanguageId == 1).SingleOrDefaultAsync();
                review.Count = (NewReview != null) ? NewReview.Count : ((review.Count != 0) ? review.Count : null);
                review.Earnings = review.Earnings != 0 ? review.Earnings : null;
                review.Cryptoloan = review.Cryptoloan != 0 ? review.Cryptoloan : null;
                review.DiversificationMinInvest = review.DiversificationMinInvest != 0 ? review.DiversificationMinInvest : null;
                review.TotalLoanValue = review.TotalLoanValue != 0 ? review.TotalLoanValue : null;
                review.NumberOfInvestors = review.NumberOfInvestors != 0 ? review.NumberOfInvestors : null;
                review.InvestorsLoss = review.InvestorsLoss != 0 ? review.InvestorsLoss : null;
                review.RiskReturn = review.RiskReturn != 0 ? review.RiskReturn : null;
                review.Usability = review.Usability != 0 ? review.Usability : null;
                review.Liquidity = review.Liquidity != 0 ? review.Liquidity : null;
                review.Support = review.Support != 0 ? review.Support : null;
                review.Interest = review.Interest != 0 ? review.Interest : null;
                review.RiskReturn = review.RiskReturn != 0 ? review.RiskReturn : null;
                review.RatingCalculated = review.RatingCalculated != 0 ? review.RatingCalculated : null;
                review.StatisticsCurrency = review.StatisticsCurrency != "string" ? review.StatisticsCurrency : null;
                review.ReportLink = review.ReportLink != 0 ? review.ReportLink : null;
                review.UpdatedDate = DateTime.Now;
                review.IsActive = review.IsActive != null ? review.IsActive : null;

                _context.Review.Add(review);
                await SaveContextChangesAsync();

                if (reviewIDTO.ReportLinkURL != null)
                {
                    var urlName = await _context.UrlTables.Where(x => x.URL.ToLower() == reviewIDTO.ReportLinkURL.ToLower()).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                    if (urlName != 0 && review.ReportLink == null)
                    {
                        review.ReportLink = urlName;
                    }
                    else if (review.ReportLink == null)
                    {
                        review.ReportLink = null;
                    }

                    await SaveContextChangesAsync();

                    if (review.ReportLink != null)
                    {
                        return await GetReviewById(review.ReviewId);
                    }
                    else
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = REVIEW_TYPEID,
                            TableId = review.ReviewId,
                            URL = reviewIDTO.ReportLinkURL
                        };
                        _context.UrlTables.Add(url);
                        await SaveContextChangesAsync();
                        review.ReportLink = url.UrlTableId;
                        await SaveContextChangesAsync();
                        return await GetReviewById(review.ReviewId);
                    }
                }
                return await GetReviewById(review.ReviewId);
            }
            catch (Exception ex)
            {
                throw ex.InnerException.InnerException;
            }
        }

        public async Task<ReviewODTO> DeleteReview(int id)
        {
            var review = await _context.Review.FindAsync(id);
            if (review == null) return null;

            var serp = await _context.Serps.Where(x => x.TableId == review.ReviewId && x.DataTypeId == REVIEW_TYPEID).ToListAsync();
            var revAttr = await _context.ReviewAttributes.Where(x => x.ReviewId == review.ReviewId).ToListAsync();
            var url = await _context.UrlTables.Where(x => x.TableId == review.ReviewId && x.DataTypeId == REVIEW_TYPEID).ToListAsync();

            if (review.LanguageId == ENG_LANG)
            {
                var reviews = await _context.Review.Where(x => x.Name == review.Name || (x.LegalName != null && x.LegalName == review.LegalName)).ToListAsync();

                foreach (var item in reviews)
                {
                    item.IsActive = false;
                    await SaveContextChangesAsync();
                    var serps = await _context.Serps.Where(x => x.TableId == item.ReviewId && x.DataTypeId == REVIEW_TYPEID).ToListAsync();
                    var revAttrs = await _context.ReviewAttributes.Where(x => x.ReviewId == item.ReviewId).ToListAsync();
                    var urls = await _context.UrlTables.Where(x => x.TableId == item.ReviewId && x.DataTypeId == REVIEW_TYPEID).ToListAsync();
                    foreach (var item2 in serps)
                    {
                        item.SerpId = null;
                        _context.Serps.Remove(item2);
                        await SaveContextChangesAsync();
                    }

                    foreach (var item3 in revAttrs)
                    {
                        _context.ReviewAttributes.Remove(item3);
                        await SaveContextChangesAsync();
                    }
                    foreach (var item4 in urls)
                    {
                        item.ReportLink = null;
                        _context.UrlTables.Remove(item4);
                        await SaveContextChangesAsync();
                    }
                }
            }
            else
            {
                review.IsActive = false;
                await SaveContextChangesAsync();
                foreach (var item in serp)
                {
                    review.SerpId = null;
                    _context.Serps.Remove(item);
                    await SaveContextChangesAsync();
                }

                foreach (var item in revAttr)
                {
                    _context.ReviewAttributes.Remove(item);
                    await SaveContextChangesAsync();
                }
                foreach (var item in url)
                {
                    review.ReportLink = null;
                    _context.UrlTables.Remove(item);
                    await SaveContextChangesAsync();
                }
            }

            var reviewODTO = await GetReviewById(id);
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
            YearMonthODTO YM = new YearMonthODTO();
            var academyreturn = await GetAcademy(id, 0, null).AsNoTracking().SingleOrDefaultAsync();

            YM = await ChangeDateFormatAdmin(null, null, null, null, academyreturn.Excerpt, academyreturn.Title);
            academyreturn.Excerpt = YM.Content;
            academyreturn.Title = YM.Title;

            return academyreturn;
        }

        public async Task<List<AcademyODTO>> GetAcademyByLangId(int langId)
        {
            YearMonthODTO YM = null;
            var academy = await GetAcademy(0, langId, null).ToListAsync();
            foreach (var item in academy)
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatAdmin(null, null, null, null, item.Excerpt, item.Title);
                item.Title = YM.Title;
                item.Excerpt = YM.Content;
            }
            return academy;
        }

        public async Task<List<PopularArticlesODTO>> GetAcademyValueByLangId(int langId)
        {
            var popularArticles = await _context.Academies.Where(x => x.LanguageId == langId).Select(e => new PopularArticlesODTO
            {
                Value = e.AcademyId,
                Label = e.Title
            }).ToListAsync();
            return popularArticles;
        }

        public async Task<List<AcademyODTO>> GetListByLangOrTag(int langId, string tag)
        {
            //var academyreturn= await GetAcademy(0, langId, tag).ToListAsync();
            var academyList = await _context.Academies.Include(x => x.UrlTable).Where(x => x.LanguageId == langId).Select(x => _mapper.Map<AcademyODTO>(x)).ToListAsync();

            YearMonthODTO ym;

            foreach (var academyreturn in academyList)
            {
                ym = new YearMonthODTO();
                ym = await ChangeDateFormatFront(null, null, null, null, academyreturn.Excerpt, academyreturn.Title, academyreturn.LanguageId);
                academyreturn.Title = ym.Title;
                academyreturn.Excerpt = ym.Content;
            }
            return academyList;
        }

        public async Task<AcademyODTO> GetAcademyFull(int id)
        {
            var gu = await _context.UrlLanguages.Where(x => x.TableID == id).Select(x => x.GUID).ToListAsync();

            var academyreturn = await (from x in _context.Academies
                   .Include(x => x.Language)
                   .Include(x => x.Serp)
                   .Include(x => x.UrlTable)
                                       where (id == 0 || x.AcademyId == id)
                                       select new AcademyODTO
                                       {
                                           AcademyId = x.AcademyId,
                                           UrlTableId = x.UrlTableId,
                                           URL = x.UrlTable.URL,
                                           SerpId = x.SerpId,
                                           LanguageId = x.LanguageId,
                                           LanguageName = x.Language.LanguageName,
                                           Title = x.Title,
                                           FeaturedImage = x.FeaturedImage,
                                           Tag = x.Tag,
                                           TitleOverview = x.TitleOverview,
                                           Excerpt = x.Excerpt,
                                           CreatedDate = x.CreatedDate,
                                           UpdatedDate = x.UpdatedDate,
                                           UO = (from y in _context.UrlLanguages
                                                 where (gu.Contains(y.GUID))
                                                 select _mapper.Map<UrlLanguagesODTO>(y)).ToList()
                                       }).SingleOrDefaultAsync();

            YearMonthODTO ym = new YearMonthODTO();
            ym = await ChangeDateFormatAdmin(null, null, null, null, null, academyreturn.Title);
            academyreturn.Title = ym.Title;
            return academyreturn;
        }

        public async Task<List<AcademyODTO>> GetAcademyByLangIdFull(int langId)
        {
            List<int> AcademyIDS = _context.Academies.Where(x => x.LanguageId == langId).Select(x => x.AcademyId).ToList();

            List<AcademyODTO> ListaAkademy = new List<AcademyODTO>();
            foreach (var id in AcademyIDS)
            {
                string guid = await _context.UrlLanguages.Where(x => x.TableID == id).Select(x => x.GUID).FirstOrDefaultAsync();
                AcademyODTO academyODTO = _context.Academies.Include(x => x.UrlTable).Include(x => x.Language).Where(x => x.AcademyId == id).Select(x => _mapper.Map<AcademyODTO>(x)).SingleOrDefault();

                academyODTO.UO = (from u in _context.UrlLanguages
                                  where (u.GUID == guid)
                                  select _mapper.Map<UrlLanguagesODTO>(u)).ToList();
                ListaAkademy.Add(academyODTO);
            }
            YearMonthODTO ym;
            foreach (var item in ListaAkademy)
            {
                ym = new YearMonthODTO();
                ym = await ChangeDateFormatAdmin(null, null, null, null, null, item.Title);
                item.Title = ym.Title;
            }
            return ListaAkademy;
        }

        public async Task<AcademyODTO> EditAcademy(AcademyIDTO academyIDTO)
        {
            var academy = _mapper.Map<Academy>(academyIDTO);

            academy.UpdatedDate = DateTime.Now;

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, academy.Excerpt, academy.Title);
            academy.Title = ym.Title;
            academy.Excerpt = ym.Content;

            _context.Entry(academy).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await GetAcademyFull(academy.AcademyId);
        }

        public async Task<UrlLanguagesODTO> AddUrlLanguage(string LinkDostava, int DataType, string LinkUnos, int? LangID, int TableId)
        {
            Entities.P2P.MainData.UrlLanguages langurl = null;

            if (LinkDostava != "string")
            {
                langurl = new Entities.P2P.MainData.UrlLanguages();
                langurl.DataTypeId = DataType;
                langurl.URL = LinkUnos;
                langurl.LanguageId = Convert.ToInt32(LangID);
                langurl.TableID = TableId;
                langurl.GUID = await _context.UrlLanguages.Where(x => x.URL == LinkDostava).Select(x => x.GUID).FirstOrDefaultAsync();
                _context.UrlLanguages.Add(langurl);
            }
            else
            {
                Guid x = Guid.NewGuid();
                langurl = new Entities.P2P.MainData.UrlLanguages();
                langurl.DataTypeId = DataType;
                langurl.URL = LinkUnos;
                langurl.LanguageId = Convert.ToInt32(LangID);
                langurl.TableID = TableId;
                langurl.GUID = x.ToString();
                _context.UrlLanguages.Add(langurl);
            }

            await SaveContextChangesAsync();
            var url = await _context.UrlLanguages.OrderByDescending(y => y.UrlLanguagesID).FirstOrDefaultAsync();

            return _mapper.Map<UrlLanguagesODTO>(url);
        }

        public async Task<AcademyODTO> AddAcademy(AcademyIDTO academyIDTO)
        {
            var academy = _mapper.Map<Academy>(academyIDTO);
            academy.AcademyId = 0;
            if (academy.LanguageId == 0)
                academy.LanguageId = null;
            if (academy.UrlTableId == 0)
                academy.UrlTableId = null;
            if (academy.SerpId == 0)
                academy.SerpId = null;

            academy.CreatedDate = DateTime.Now;
            academy.UpdatedDate = null;

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, null, academy.Title);
            academy.Title = ym.Title;

            _context.Academies.Add(academy);
            await SaveContextChangesAsync();

            return await GetAcademyFull(academy.AcademyId);
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
                   .Include(x => x.Serp)
                   where (id == 0 || x.PagesSettingsId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<PagesSettingsODTO>(x);
        }

        public async Task<PagesSettingsODTO> GetPagesSettingsById(int id)
        {
            var result = await GetPagesSettings(id, 0).AsNoTracking().FirstOrDefaultAsync();
            YearMonthODTO ym;
            ym = await ChangeDateFormatAdmin(result.SerpTitle, result.SerpDescription, result.Subtitle, null, null, result.Title);
            result.SerpTitle = ym.SerpTitle;
            result.SerpDescription = ym.SerpDescription;
            result.Subtitle = ym.Subtitle;
            result.Title = ym.Title;

            return result;
        }

        public async Task<PagesSettingsODTO> GetPagesSettingsByLangId(int langId)
        {
            return await GetPagesSettings(0, langId).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<PagesSettingsODTO> GetNewsSettingsByLangId(int langId, string UseCase)
        {
            YearMonthODTO YM;
            var NewsSettings = await _context.PagesSettings.Where(x => x.LanguageId == langId && x.DataTypeId == NEWS_SETTINGS_TYPEID).Select(x =>
                     new PagesSettingsODTO
                     {
                         PagesSettingsId = x.PagesSettingsId,
                         LanguageId = x.LanguageId,
                         LanguageName = x.Language.LanguageName,
                         SerpId = x.SerpId,
                         SerpTitle = x.Serp.SerpTitle,
                         SerpDescription = x.Serp.SerpDescription,
                         Subtitle = x.Serp.Subtitle,
                         DataTypeId = x.DataTypeId,
                         DataTypeName = x.DataType.DataTypeName,
                         Platform = x.Platform,
                         Title = x.Title,
                     }).FirstOrDefaultAsync();

            if (UseCase == "Dashboard")
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatAdmin(NewsSettings.SerpTitle, NewsSettings.SerpDescription, NewsSettings.Subtitle, null, null, NewsSettings.Title);
                NewsSettings.SerpTitle = YM.SerpTitle;
                NewsSettings.SerpDescription = YM.SerpDescription;
                NewsSettings.Subtitle = YM.Subtitle;
                NewsSettings.Title = YM.Title;

            }
            else
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatFront(NewsSettings.SerpTitle, NewsSettings.SerpDescription, NewsSettings.Subtitle, null, null, NewsSettings.Title, NewsSettings.LanguageId);
                NewsSettings.SerpTitle = YM.SerpTitle;
                NewsSettings.SerpDescription = YM.SerpDescription;
                NewsSettings.Subtitle = YM.Subtitle;
                NewsSettings.Title = YM.Title;
            }

            return NewsSettings;

        }

        public async Task<PagesSettingsODTO> GetBlogSettingsByLangId(int langId, string UseCase)
        {
            YearMonthODTO YM;
            var BlogSettings = await _context.PagesSettings.Where(x => x.LanguageId == langId && x.DataTypeId == BLOG_SETTINGS_TYPEID).Select(x =>
                     new PagesSettingsODTO
                     {
                         PagesSettingsId = x.PagesSettingsId,
                         LanguageId = x.LanguageId,
                         LanguageName = x.Language.LanguageName,
                         SerpId = x.SerpId,
                         SerpTitle = x.Serp.SerpTitle,
                         SerpDescription = x.Serp.SerpDescription,
                         Subtitle = x.Serp.Subtitle,
                         PageSettingsSubtitle = x.PageSettingsSubtitle,
                         DataTypeId = x.DataTypeId,
                         DataTypeName = x.DataType.DataTypeName,
                         Platform = x.Platform,
                         Title = x.Title,
                     }).FirstOrDefaultAsync();

            if (UseCase == "Dashboard")
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatAdmin(BlogSettings.SerpTitle, BlogSettings.SerpDescription, BlogSettings.Subtitle, null, null, BlogSettings.Title);
                BlogSettings.SerpTitle = YM.SerpTitle;
                BlogSettings.SerpDescription = YM.SerpDescription;
                BlogSettings.Subtitle = YM.Subtitle;
                BlogSettings.Title = YM.Title;

            }
            else
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatFront(BlogSettings.SerpTitle, BlogSettings.SerpDescription, BlogSettings.Subtitle, null, null, BlogSettings.Title, BlogSettings.LanguageId);
                BlogSettings.SerpTitle = YM.SerpTitle;
                BlogSettings.SerpDescription = YM.SerpDescription;
                BlogSettings.Subtitle = YM.Subtitle;
                BlogSettings.Title = YM.Title;
            }

            return BlogSettings;
        }

        public async Task<PagesSettingsODTO> GetBonusSettingsByLangId(int langId, string UseCase)
        {
            YearMonthODTO YM;
            var BonusSettings = await _context.PagesSettings.Where(x => x.LanguageId == langId && x.DataTypeId == BONUS_SETTINGS_TYPEID).Select(x =>
                     new PagesSettingsODTO
                     {
                         PagesSettingsId = x.PagesSettingsId,
                         LanguageId = x.LanguageId,
                         LanguageName = x.Language.LanguageName,
                         SerpId = x.SerpId,
                         SerpTitle = x.Serp.SerpTitle,
                         SerpDescription = x.Serp.SerpDescription,
                         Subtitle = x.Serp.Subtitle,
                         DataTypeId = x.DataTypeId,
                         DataTypeName = x.DataType.DataTypeName,
                         Platform = x.Platform,
                         Title = x.Title,
                     }).FirstOrDefaultAsync();

            if (UseCase == "Dashboard")
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatAdmin(BonusSettings.SerpTitle, BonusSettings.SerpDescription, BonusSettings.Subtitle, null, null, BonusSettings.Title);
                BonusSettings.SerpTitle = YM.SerpTitle;
                BonusSettings.SerpDescription = YM.SerpDescription;
                BonusSettings.Subtitle = YM.Subtitle;
                BonusSettings.Title = YM.Title;

            }
            else
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatFront(BonusSettings.SerpTitle, BonusSettings.SerpDescription, BonusSettings.Subtitle, null, null, BonusSettings.Title, BonusSettings.LanguageId);
                BonusSettings.SerpTitle = YM.SerpTitle;
                BonusSettings.SerpDescription = YM.SerpDescription;
                BonusSettings.Subtitle = YM.Subtitle;
                BonusSettings.Title = YM.Title;
            }

            return BonusSettings;
        }

        public async Task<PagesSettingsODTO> GetAcademySettingsByLangId(int langId, string UseCase)
        {
            YearMonthODTO YM;
            var AcademySettings = await _context.PagesSettings.Where(x => x.LanguageId == langId && x.DataTypeId == ACADEMY_SETTINGS_TYPEID).Select(x =>
                     new PagesSettingsODTO
                     {
                         PagesSettingsId = x.PagesSettingsId,
                         LanguageId = x.LanguageId,
                         LanguageName = x.Language.LanguageName,
                         SerpId = x.SerpId,
                         SerpTitle = x.Serp.SerpTitle,
                         SerpDescription = x.Serp.SerpDescription,
                         Subtitle = x.Serp.Subtitle,
                         DataTypeId = x.DataTypeId,
                         DataTypeName = x.DataType.DataTypeName,
                         Platform = x.Platform,
                         Title = x.Title,
                     }).FirstOrDefaultAsync();

            if (UseCase == "Dashboard")
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatAdmin(AcademySettings.SerpTitle, AcademySettings.SerpDescription, AcademySettings.Subtitle, null, null, AcademySettings.Title);
                AcademySettings.SerpTitle = YM.SerpTitle;
                AcademySettings.SerpDescription = YM.SerpDescription;
                AcademySettings.Subtitle = YM.Subtitle;
                AcademySettings.Title = YM.Title;

            }
            else
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatFront(AcademySettings.SerpTitle, AcademySettings.SerpDescription, AcademySettings.Subtitle, null, null, AcademySettings.Title, AcademySettings.LanguageId);
                AcademySettings.SerpTitle = YM.SerpTitle;
                AcademySettings.SerpDescription = YM.SerpDescription;
                AcademySettings.Subtitle = YM.Subtitle;
                AcademySettings.Title = YM.Title;
            }

            return AcademySettings;
        }

        public async Task<PagesSettingsODTO> GetReviewSettingsByLangId(int langId, string UseCase)
        {
            YearMonthODTO YM;
            var ReviewSettings = await _context.PagesSettings.Where(x => x.LanguageId == langId && x.DataTypeId == REVIEW_SETTINGS_TYPEID).Select(x =>
                     new PagesSettingsODTO
                     {
                         PagesSettingsId = x.PagesSettingsId,
                         LanguageId = x.LanguageId,
                         LanguageName = x.Language.LanguageName,
                         SerpId = x.SerpId,
                         SerpTitle = x.Serp.SerpTitle,
                         SerpDescription = x.Serp.SerpDescription,
                         Subtitle = x.Serp.Subtitle,
                         DataTypeId = x.DataTypeId,
                         DataTypeName = x.DataType.DataTypeName,
                         Platform = x.Platform,
                         Title = x.Title,
                     }).FirstOrDefaultAsync();

            if (UseCase == "Dashboard")
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatAdmin(ReviewSettings.SerpTitle, ReviewSettings.SerpDescription, ReviewSettings.Subtitle, null, null, ReviewSettings.Title);
                ReviewSettings.SerpTitle = YM.SerpTitle;
                ReviewSettings.SerpDescription = YM.SerpDescription;
                ReviewSettings.Subtitle = YM.Subtitle;
                ReviewSettings.Title = YM.Title;

            }
            else
            {
                YM = new YearMonthODTO();
                YM = await ChangeDateFormatFront(ReviewSettings.SerpTitle, ReviewSettings.SerpDescription, ReviewSettings.Subtitle, null, null, ReviewSettings.Title, ReviewSettings.LanguageId);
                ReviewSettings.SerpTitle = YM.SerpTitle;
                ReviewSettings.SerpDescription = YM.SerpDescription;
                ReviewSettings.Subtitle = YM.Subtitle;
                ReviewSettings.Title = YM.Title;
            }

            return ReviewSettings;
        }

        public async Task<PagesSettingsODTO> EditPagesSettings(PagesSettingsIDTO pagesSettingsIDTO)
        {
            var pagesSettings = _mapper.Map<PagesSettings>(pagesSettingsIDTO);

            _context.Entry(pagesSettings).State = EntityState.Modified;

            var serp = await _context.Serps.Where(x => x.SerpId == pagesSettings.SerpId).SingleOrDefaultAsync();
            serp.SerpTitle = pagesSettingsIDTO.SerpTitle;
            serp.SerpDescription = pagesSettingsIDTO.SerpDescription;
            serp.Subtitle = pagesSettingsIDTO.Subtitle;

            YearMonthODTO YM = new YearMonthODTO();
            YM = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, pagesSettings.Title);
            pagesSettings.Serp.SerpTitle = YM.SerpTitle;
            pagesSettings.Serp.SerpDescription = YM.SerpDescription;
            pagesSettings.Serp.Subtitle = YM.Subtitle;
            pagesSettings.Title = YM.Title;

            _context.Entry(pagesSettings).State = EntityState.Modified;
            _context.Entry(serp).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetPagesSettingsById(pagesSettings.PagesSettingsId);
        }

        public async Task<PagesSettingsODTO> AddPagesSettings(PagesSettingsIDTO pagesSettingsIDTO)
        {
            try
            {
                var pageSett = _mapper.Map<PagesSettings>(pagesSettingsIDTO);
                var serp = new Serp
                {
                    DataTypeId = pagesSettingsIDTO.DataTypeId,
                    SerpTitle = pagesSettingsIDTO.SerpTitle,
                    SerpDescription = pagesSettingsIDTO.SerpDescription,
                    Subtitle = pagesSettingsIDTO.Subtitle
                };

                YearMonthODTO YM = new YearMonthODTO();
                YM = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, null);
                serp.SerpTitle = YM.SerpTitle;
                serp.SerpDescription = YM.SerpDescription;
                serp.Subtitle = YM.Subtitle;

                _context.Serps.Add(serp);
                await SaveContextChangesAsync();
                pageSett.PagesSettingsId = 0;
                pageSett.SerpId = serp.SerpId;

                YearMonthODTO YM1 = new YearMonthODTO();
                YM1 = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, pageSett.Title);
                pageSett.Title = YM1.Title;

                _context.PagesSettings.Add(pageSett);
                await SaveContextChangesAsync();

                serp.TableId = pageSett.PagesSettingsId;
                await SaveContextChangesAsync();

                return await GetPagesSettingsById(pageSett.PagesSettingsId);
            }
            catch (Exception ex)
            {
                throw ex.InnerException.InnerException;
            }
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
            var NewsFeed = await GetNewsFeed(id, 0).AsNoTracking().SingleOrDefaultAsync();
            YearMonthODTO ym = await ChangeDateFormatAdmin(null, null, null, null, NewsFeed.NewsText, NewsFeed.TagLine);
            NewsFeed.NewsText = ym.Content;
            NewsFeed.TagLine = ym.Title;

            return NewsFeed;
        }

        public async Task<List<GetNewsFeedListODTO>> GetListNewsFeedByLangId(int languageId, string UseCase)
        {
            var newsFeed = await _context.NewsFeeds.Where(x => x.LanguageId == languageId).Select(x => new GetNewsFeedListODTO
            {
                Name = _context.Review.Where(e => e.ReviewId == x.ReviewId && e.IsActive == true).Select(x => x.Name).FirstOrDefault(),
                NewsText = x.NewsText,
                CreatedDate = x.CreatedDate,
                NewsFeedId = x.NewsFeedId,
                Market = x.Market,
                TagLine = x.TagLine,
                UrlTableId = x.UrlTableId,
                URL = x.UrlTable.URL,
                RedFlag = x.RedFlag,
                Route = _context.Routes.Where(e => e.DataTypeId == REVIEW_TYPEID && e.TableId == x.ReviewId).Select(x => _mapper.Map<UrlTableODTO>(x.UrlTable)).FirstOrDefault(),
                Logo = _context.Review.Where(e => e.ReviewId == x.ReviewId && e.IsActive == true).Select(e => e.Logo).FirstOrDefault()
            }).OrderBy(x => x.CreatedDate).ToListAsync();

            YearMonthODTO YM;
            if (UseCase == "Dashboard")
            {
                foreach (var item in newsFeed)
                {
                    YM = new YearMonthODTO();
                    YM = await ChangeDateFormatAdmin(item.NewsText, item.TagLine, null, null, null, null);
                    item.NewsText = YM.SerpTitle;
                    item.TagLine = YM.SerpDescription;
                }
            }
            else
            {
                foreach (var item in newsFeed)
                {
                    YM = new YearMonthODTO();
                    YM = await ChangeDateFormatFront(item.NewsText, item.TagLine, null, null, null, null, languageId);
                    item.NewsText = YM.SerpTitle;
                    item.TagLine = YM.SerpDescription;
                    //There is a chance that we also need item.Paragraph
                }
            }

            return newsFeed;
        }

        public async Task<List<GetNewsFeedListODTO>> GetAllNews(int Id)
        {
            if (Id != 0)
            {
                return await (from x in _context.NewsFeeds
                              where (x.NewsFeedId == Id)
                              select new GetNewsFeedListODTO
                              {
                                  Route = _context.Routes.Where(e => e.DataTypeId == REVIEW_TYPEID && e.TableId == x.ReviewId).Select(x => _mapper.Map<UrlTableODTO>(x.UrlTable)).FirstOrDefault(),
                                  NewsText = x.NewsText,
                                  CreatedDate = x.CreatedDate,
                                  NewsFeedId = x.NewsFeedId,
                                  Name = _context.Review.Where(e => e.ReviewId == x.ReviewId && e.IsActive == true).Select(x => x.Name).FirstOrDefault(),
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
                              join r in _context.Routes.Where(e => e.DataTypeId == REVIEW_TYPEID) on x.ReviewId equals r.TableId into c
                              from b in c.DefaultIfEmpty()
                              select new GetNewsFeedListODTO
                              {
                                  NewsText = x.NewsText,
                                  CreatedDate = x.CreatedDate,
                                  NewsFeedId = x.NewsFeedId,
                                  Name = x.Review.Name,
                                  Route = _mapper.Map<UrlTableODTO>(b.UrlTable),
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
            var newsFeeds = _mapper.Map<NewsFeed>(newsFeedIDTO);
            YearMonthODTO YM = await EditDate(newsFeeds.NewsText, newsFeeds.TagLine, null, null, null, null);
            newsFeeds.NewsText = YM.SerpTitle;
            newsFeeds.TagLine = YM.SerpDescription;
            _context.Entry(newsFeeds).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetNewsFeedById(newsFeeds.NewsFeedId);
        }

        public async Task<NewsFeedODTO> AddNewsFeed(NewsFeedIDTO newsFeedIDTO)
        {
            var newsFeeds = _mapper.Map<NewsFeed>(newsFeedIDTO);
            newsFeeds.NewsFeedId = 0;
            if (newsFeeds.ReviewId == 0)
                newsFeeds.ReviewId = null;
            newsFeeds.UrlTableId = null;

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(null, null, null, null, newsFeeds.NewsText, newsFeeds.TagLine);
            newsFeeds.NewsText = ym.Content;
            newsFeeds.TagLine = ym.Title;

            _context.NewsFeeds.Add(newsFeeds);
            await SaveContextChangesAsync();
            if (newsFeedIDTO.Url != null)
            {
                var url = new UrlTable
                {
                    DataTypeId = NEWS_FEED_TYPEID,
                    TableId = newsFeeds.NewsFeedId,
                    URL = newsFeedIDTO.Url
                };
                _context.UrlTables.Add(url);
                await SaveContextChangesAsync();
                newsFeeds.UrlTableId = url.UrlTableId;
                await SaveContextChangesAsync();
            }
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

        public async Task<List<HomeSettingsODTO>> GetHomeSettingsByLangId(int langId, string UseCase)
        {
            List<string> reviewPlatforms = new List<string>();
            foreach (var platform in await (from x in _context.HomeSettings
                                            where x.LanguageId == langId
                                            select x.Platform).ToListAsync())
            {
                reviewPlatforms = platform.Split(',').ToList();
            }
            List<RoutesForHomeSettingsByLangODTO> data = (from a in _context.Routes
                                     .Include(x => x.UrlTable)
                                     .Include(x => x.Language)
                                     .Include(x => x.DataType)
                                                          where reviewPlatforms.Contains(a.TableId.ToString()) && a.DataTypeId == REVIEW_TYPEID
                                                          select new RoutesForHomeSettingsByLangODTO
                                                          {
                                                              RoutesId = a.RoutesId,
                                                              DataTypeId = a.DataTypeId,
                                                              DataTypeName = a.DataType.DataTypeName,
                                                              UrlTableId = a.UrlTableId,
                                                              URL = a.UrlTable.URL,
                                                              LanguageId = a.LanguageId,
                                                              LanguageName = a.Language.LanguageName,
                                                              TableId = a.TableId
                                                          }).ToList();

            List<RoutesForHomeSettingsByLangODTO> SortedList = data.OrderBy(o => o.TableId).ToList();

            foreach (var item in SortedList)
            {
                var review = await _context.Review.Where(x => x.ReviewId == item.TableId && item.DataTypeId == REVIEW_TYPEID && x.IsActive == true).Select(x => x.Name).FirstOrDefaultAsync();
                if (review != null)
                    item.ExternalLinkKey = await _context.Links.Include(x => x.UrlTable).Where(x => x.Key.ToLower() == review.ToLower()).Select(x => x.UrlTable.URL).FirstOrDefaultAsync();
            }

            List<HomeSettingsODTO> homeSettings = await (from x in _context.HomeSettings
                                                         where x.LanguageId == langId
                                                         select new HomeSettingsODTO
                                                         {
                                                             HomeSettingsId = x.HomeSettingsId,
                                                             NewsUrl = x.NewsUrl,
                                                             NewsUrlLink = x.NewsUrls.URL,
                                                             Platforms = x.Platforms,
                                                             ReviewUrl = x.ReviewUrl,
                                                             ReviewUrlLink = x.ReviewUrls.URL,
                                                             SerpId = x.SerpId,
                                                             SerpTitle = x.Serp.SerpTitle,
                                                             SerpDescription = x.Serp.SerpDescription,
                                                             Subtitle = x.Serp.Subtitle,
                                                             AcademyUrl = x.AcademyUrl,
                                                             AcademyUrlLink = x.AcademyUrls.URL,
                                                             BonusUrl = x.BonusUrl,
                                                             BonusUrlLink = x.BonusUrls.URL,
                                                             LanguageId = x.LanguageId,
                                                             LanguageName = x.Language.LanguageName,
                                                             Title = x.Title,
                                                             Returned = x.Returned,
                                                             Investment = x.Investment,
                                                             TestimonialH2 = x.TestimonialH2,
                                                             FeaturedH2 = x.FeaturedH2,
                                                             LinkToUrl = SortedList,
                                                             Platform = x.Platform,
                                                             ReviewList = (from a in _context.Review
                                                                           .Include(x => x.Serp)
                                                                           .Include(x => x.Language)
                                                                           .Include(x => x.Rev_FacebookUrl)
                                                                           .Include(x => x.Rev_InstagramUrl)
                                                                           .Include(x => x.Rev_LinkedInUrl)
                                                                           .Include(x => x.Rev_TwitterUrl)
                                                                           .Include(x => x.Rev_YoutubeUrl)
                                                                           .Include(x => x.Rev_ReportLink)
                                                                           where (reviewPlatforms.Contains(a.ReviewId.ToString()))
                                                                           select _mapper.Map<ReviewODTO>(a)).ToList(),
                                                             TrackH2 = (from a in _context.SettingsAttributes
                                                                              .Include(x => x.Language)
                                                                              .Include(x => x.DataType)
                                                                              .Include(x => x.SettingsDataType)
                                                                        where (a.DataTypeId == HOME_SETTINGS_TYPEID)
                                                                        && (a.SettingsDataTypeId == TRACKH2_TYPEID)
                                                                        && (a.LanguageId == langId)
                                                                        select _mapper.Map<SettingsAttributeODTO>(a)).ToList(),
                                                             TrackH3 = (from b in _context.SettingsAttributes
                                                                              .Include(x => x.SettingsDataType)
                                                                        where (b.DataTypeId == HOME_SETTINGS_TYPEID)
                                                                        && (b.SettingsDataTypeId == TRACKH3_TYPEID)
                                                                        && (b.LanguageId == langId)
                                                                        select _mapper.Map<SettingsAttributeODTO>(b)).ToList(),
                                                             Trackparahraph = (from c in _context.SettingsAttributes
                                                                              .Include(x => x.SettingsDataType)
                                                                               where (c.DataTypeId == HOME_SETTINGS_TYPEID)
                                                                               && (c.SettingsDataTypeId == TRACKHPARAGRAPH_TYPEID)
                                                                               && (c.LanguageId == langId)
                                                                               select _mapper.Map<SettingsAttributeODTO>(c)).ToList(),
                                                         }).ToListAsync();

            YearMonthODTO YM;
            if (UseCase == "Dashboard")
            {
                foreach (var item in homeSettings)
                {
                    YM = new YearMonthODTO();
                    YM = await ChangeDateFormatAdmin(item.SerpTitle, item.SerpDescription, item.Subtitle, null, null, item.Title);
                    item.SerpTitle = YM.SerpTitle;
                    item.SerpDescription = YM.SerpDescription;
                    item.Subtitle = YM.Subtitle;
                    item.Title = YM.Title;
                }
            }
            else
            {
                foreach (var item in homeSettings)
                {
                    YM = new YearMonthODTO();
                    YM = await ChangeDateFormatFront(item.SerpTitle, item.SerpDescription, item.Subtitle, null, null, item.Title, item.LanguageId);
                    item.SerpTitle = YM.SerpTitle;
                    item.SerpDescription = YM.SerpDescription;
                    item.Subtitle = YM.Subtitle;
                    item.Title = YM.Title;
                }
            }

            return homeSettings;
        }

        public async Task<HomeSettingsODTO> EditHomeSettings(HomeSettingsIDTO homeSettingsIDTO)
        {
            var homeSettings = _mapper.Map<HomeSettings>(homeSettingsIDTO);
            homeSettings.SerpId = homeSettings.SerpId != 0 ? homeSettings.SerpId : null;
            homeSettings.AcademyUrl = homeSettings.AcademyUrl != 0 ? homeSettings.AcademyUrl : null;
            homeSettings.BonusUrl = homeSettings.BonusUrl != 0 ? homeSettings.BonusUrl : null;
            homeSettings.NewsUrl = homeSettings.NewsUrl != 0 ? homeSettings.NewsUrl : null;
            homeSettings.ReviewUrl = homeSettings.ReviewUrl != 0 ? homeSettings.ReviewUrl : null;
            _context.Entry(homeSettings).State = EntityState.Modified;

            await SaveContextChangesAsync();

            var AllHomesettings = await _context.HomeSettings.Where(x => x.LanguageId == 1).SingleOrDefaultAsync();

            foreach (var item in _context.HomeSettings.ToList())
            {
                item.Investment = (homeSettings.Investment == null) ? 0 : AllHomesettings.Investment;
                item.Returned = (homeSettings.Returned == null) ? 0 : AllHomesettings.Returned;
                item.Platforms = (homeSettings.Platforms == null) ? 0 : AllHomesettings.Platforms;
                _context.Entry(homeSettings).State = EntityState.Modified;
            }
            await SaveContextChangesAsync();

            var serp = new Serp
            {
                SerpTitle = homeSettingsIDTO.SerpTitle,
                SerpDescription = homeSettingsIDTO.SerpDescription,
                Subtitle = homeSettingsIDTO.Subtitle,
                DataTypeId = HOME_SETTINGS_TYPEID,
                TableId = homeSettings.HomeSettingsId
            };

            YearMonthODTO YM = new YearMonthODTO();
            YM = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, homeSettings.Title);
            serp.SerpTitle = YM.SerpTitle;
            serp.SerpDescription = YM.SerpDescription;
            serp.Subtitle = YM.Subtitle;
            homeSettings.Title = YM.Title;
            _context.Entry(homeSettings).State = EntityState.Modified;
            _context.Serps.Add(serp);
            await SaveContextChangesAsync();

            homeSettings.SerpId = serp.SerpId;
            await SaveContextChangesAsync();

            var propNames = new string[] { "AcademyUrl", "BonusUrl", "NewsUrl", "ReviewUrl" };
            var urlNames = new string[] { "AcademyUrlLink", "BonusUrlLink", "NewsUrlLink", "ReviewUrlLink" };

            for (int i = 0; i < urlNames.Length; i++)
            {
                if (homeSettingsIDTO.GetType().GetProperty(urlNames[i])?.GetValue(homeSettingsIDTO, null) != null)
                {
                    var urlid = await _context.UrlTables.Where(x => x.URL.ToLower() == homeSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(homeSettingsIDTO, null).ToString().ToLower() && x.DataTypeId == HOME_SETTINGS_TYPEID && x.TableId == homeSettingsIDTO.HomeSettingsId).Select(x => x.UrlTableId).FirstOrDefaultAsync();

                    if (urlid != 0)
                    {
                        homeSettings.GetType().GetProperty(propNames[i]).SetValue(homeSettings, urlid);
                        _context.Entry(homeSettings).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = HOME_SETTINGS_TYPEID,
                            URL = homeSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(homeSettingsIDTO, null).ToString(),
                            TableId = homeSettings.HomeSettingsId,
                        };
                        _context.UrlTables.Add(url);
                        await _context.SaveChangesAsync();

                        homeSettings.GetType().GetProperty(propNames[i]).SetValue(homeSettings, url.UrlTableId);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            var settAttr = new SettingsAttribute();
            if (homeSettingsIDTO.SettingsAttributes != null)
            {
                foreach (var item in homeSettingsIDTO.SettingsAttributes)
                {
                    settAttr = new SettingsAttribute
                    {
                        SettingsAttributeId = item.SettingsAttributeId,
                        DataTypeId = HOME_SETTINGS_TYPEID,
                        SettingsDataTypeId = item.SettingsDataTypeId,
                        LanguageId = item.LanguageId,
                        Value = item.Value,
                        Index = item.Index,
                        UrlTableId = null,
                    };
                    var urlId = await _context.UrlTables.Where(x => x.URL.ToLower() == settAttr.Value && x.DataTypeId == settAttr.DataTypeId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                    settAttr.UrlTableId = settAttr.Value != null && urlId != 0 ? urlId : null;
                    _context.Entry(settAttr).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                    if (settAttr.UrlTableId != null)
                    {
                        if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID))
                        {
                            settAttr.Value = null;
                            await SaveContextChangesAsync();
                        }
                        else
                        {
                            settAttr.UrlTableId = null;
                            await SaveContextChangesAsync();
                        }
                    }
                    else if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = settAttr.DataTypeId,
                            URL = settAttr.Value,
                            TableId = settAttr.SettingsAttributeId,
                        };
                        _context.UrlTables.Add(url);
                        await SaveContextChangesAsync();
                        settAttr.UrlTableId = url.UrlTableId;
                        settAttr.Value = null;
                        await SaveContextChangesAsync();
                    }
                }
            }

            return await GetHomeSettingsById(homeSettings.HomeSettingsId);
        }

        public async Task<HomeSettingsODTO> AddHomeSettings(HomeSettingsIDTO homeSettingsIDTO)
        {
            var homeSettings = _mapper.Map<HomeSettings>(homeSettingsIDTO);
            homeSettings.HomeSettingsId = 0;
            homeSettings.SerpId = homeSettings.SerpId != 0 ? homeSettings.SerpId : null;
            homeSettings.AcademyUrl = homeSettings.AcademyUrl != 0 ? homeSettings.AcademyUrl : null;
            homeSettings.BonusUrl = homeSettings.BonusUrl != 0 ? homeSettings.BonusUrl : null;
            homeSettings.NewsUrl = homeSettings.NewsUrl != 0 ? homeSettings.NewsUrl : null;
            homeSettings.ReviewUrl = homeSettings.ReviewUrl != 0 ? homeSettings.ReviewUrl : null;
            _context.HomeSettings.Add(homeSettings);
            await SaveContextChangesAsync();

            var serp = new Serp
            {
                SerpTitle = homeSettingsIDTO.SerpTitle,
                SerpDescription = homeSettingsIDTO.SerpDescription,
                Subtitle = homeSettingsIDTO.Subtitle,
                DataTypeId = HOME_SETTINGS_TYPEID,
                TableId = homeSettings.HomeSettingsId
            };

            YearMonthODTO YM = new YearMonthODTO();
            YM = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, homeSettings.Title);
            serp.SerpTitle = YM.SerpTitle;
            serp.SerpDescription = YM.SerpDescription;
            serp.Subtitle = YM.Subtitle;
            homeSettings.Title = YM.Title;

            _context.Entry(homeSettings).State = EntityState.Modified;
            await SaveContextChangesAsync();

            _context.Serps.Add(serp);
            await SaveContextChangesAsync();

            homeSettings.SerpId = serp.SerpId;
            await SaveContextChangesAsync();

            var propNames = new string[] { "AcademyUrl", "BonusUrl", "NewsUrl", "ReviewUrl" };
            var urlNames = new string[] { "AcademyUrlLink", "BonusUrlLink", "NewsUrlLink", "ReviewUrlLink" };

            for (int i = 0; i < urlNames.Length; i++)
            {
                if (homeSettingsIDTO.GetType().GetProperty(urlNames[i])?.GetValue(homeSettingsIDTO, null) != null)
                {
                    var url = new UrlTable
                    {
                        DataTypeId = HOME_SETTINGS_TYPEID,
                        URL = homeSettingsIDTO.GetType().GetProperty(urlNames[i]).GetValue(homeSettingsIDTO, null).ToString(),
                        TableId = homeSettings.HomeSettingsId,
                    };
                    _context.UrlTables.Add(url);
                    await _context.SaveChangesAsync();

                    homeSettings.GetType().GetProperty(propNames[i]).SetValue(homeSettings, url.UrlTableId);
                    await _context.SaveChangesAsync();
                }
            }

            if (homeSettingsIDTO.SettingsAttributes != null)
            {
                SettingsAttribute settAtr = new SettingsAttribute();
                foreach (var item in homeSettingsIDTO.SettingsAttributes)
                {
                    settAtr = new SettingsAttribute
                    {
                        DataTypeId = item.DataTypeId,
                        SettingsDataTypeId = item.SettingsDataTypeId,
                        LanguageId = item.LanguageId,
                        Value = item.Value,
                        Index = item.Index,
                        UrlTableId = null,
                    };
                    var settAtrReal = await _context.SettingsAttributes.Where(x => x.DataTypeId == item.DataTypeId && x.SettingsDataTypeId == item.SettingsDataTypeId
                    && x.LanguageId == item.LanguageId && x.Value == item.Value && x.Index == item.Index && x.UrlTableId == item.UrlTableId).SingleOrDefaultAsync();

                    if (settAtrReal == null)
                    {
                        _context.SettingsAttributes.Add(settAtr);
                        await SaveContextChangesAsync();
                    }
                    else
                    {
                        _context.Entry(settAtr).State = EntityState.Modified;
                        await SaveContextChangesAsync();
                    }
                }
            }

            return await GetHomeSettingsById(homeSettings.HomeSettingsId);
        }

        public async Task<HomeSettingsODTO> DeleteHomeSettings(int id)
        {
            var homeSettings = await _context.HomeSettings.FindAsync(id);
            if (homeSettings == null) return null;

            var homeUrl = await _context.UrlTables.Where(x => x.TableId == homeSettings.HomeSettingsId && x.DataTypeId == HOME_SETTINGS_TYPEID).ToListAsync();
            var homeSerp = await _context.Serps.Where(x => x.TableId == homeSettings.HomeSettingsId && x.DataTypeId == HOME_SETTINGS_TYPEID).ToListAsync();
            var homeAttr = await _context.SettingsAttributes.Where(x => x.LanguageId == homeSettings.LanguageId && x.DataTypeId == HOME_SETTINGS_TYPEID).ToListAsync();

            var homeSettingsODTO = await GetHomeSettingsById(id);
            _context.HomeSettings.Remove(homeSettings);
            await SaveContextChangesAsync();

            if (homeUrl != null)
            {
                foreach (var item in homeUrl)
                {
                    _context.UrlTables.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            if (homeSerp != null)
            {
                foreach (var item in homeSerp)
                {
                    _context.Serps.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            if (homeAttr != null)
            {
                foreach (var item in homeAttr)
                {
                    var x = await _context.UrlTables.Where(x => x.UrlTableId == item.UrlTableId).FirstOrDefaultAsync();
                    _context.SettingsAttributes.Remove(item);
                    await SaveContextChangesAsync();
                    if (x != null)
                    {
                        _context.UrlTables.Remove(x);
                        await SaveContextChangesAsync();
                    }
                }
            }

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

        public async Task<List<AboutSettingsODTO>> GetAboutSettingsByLangId(int langId, string UseCase)
        {
            List<AboutSettingsODTO> aboutSettings = await (from x in _context.AboutSettings
                                                           where x.LanguageId == langId
                                                           select new AboutSettingsODTO
                                                           {
                                                               AboutSettingsId = x.AboutSettingsId,
                                                               SerpId = x.SerpId,
                                                               SerpDescription = x.Serp.SerpDescription,
                                                               SerpTitle = x.Serp.SerpTitle,
                                                               Subtitle = x.Serp.Subtitle,
                                                               LanguageId = x.LanguageId,
                                                               Paragraph = x.Paragraph,
                                                               TeamH2 = x.TeamH2,
                                                               Title = x.Title,
                                                               VideoCode = x.VideoCode,
                                                               VideoDescription = x.VideoDescription,
                                                               Section1H2 = x.Section1H2,
                                                               Section1H3 = x.Section1H3,
                                                               Section2H2 = x.Section2H2,
                                                               Section2Paragraph = x.Section2Paragraph,
                                                               TestimonialH2 = x.TestimonialH2,
                                                               memberRole = (from a in _context.SettingsAttributes
                                                                              .Include(x => x.Language)
                                                                              .Include(x => x.DataType)
                                                                              .Include(x => x.SettingsDataType)
                                                                             where (a.DataTypeId == ABOUT_SETTINGS_TYPEID)
                                                                             && (a.SettingsDataTypeId == MEMBER_ROLE_TYPEID)
                                                                             && (a.LanguageId == langId)
                                                                             select _mapper.Map<SettingsAttributeODTO>(a)).ToList(),
                                                               memberImageUrl = (from v in _context.SettingsAttributes
                                                                                 .Include(x => x.SettingsDataType)
                                                                                 where (v.DataTypeId == ABOUT_SETTINGS_TYPEID)
                                                                                 && (v.SettingsDataTypeId == MEMBER_IMAGE_TYPEID)
                                                                                 && (v.LanguageId == langId)
                                                                                 select _mapper.Map<SettingsAttributeODTO>(v)).ToList(),
                                                               memberName = (from c in _context.SettingsAttributes
                                                                             .Include(x => x.SettingsDataType)
                                                                             where (c.DataTypeId == ABOUT_SETTINGS_TYPEID)
                                                                             && (c.SettingsDataTypeId == MEMBER_NAME_TYPEID)
                                                                             && (c.LanguageId == langId)
                                                                             select _mapper.Map<SettingsAttributeODTO>(c)).ToList()
                                                           }).ToListAsync();
            YearMonthODTO YM;
            if (UseCase == "Dashboard")
            {
                foreach (var item in aboutSettings)
                {
                    YM = new YearMonthODTO();
                    YM = await ChangeDateFormatAdmin(item.SerpTitle, item.SerpDescription, item.Subtitle, item.Paragraph, item.Section2Paragraph, item.Title);
                    item.SerpTitle = YM.SerpTitle;
                    item.SerpDescription = YM.SerpDescription;
                    item.Subtitle = YM.Subtitle;
                    item.Title = YM.Title;
                    item.Paragraph = YM.PageTitle;
                    item.Section2Paragraph = YM.Content;
                }
            }
            else
            {
                foreach (var item in aboutSettings)
                {
                    YM = new YearMonthODTO();
                    YM = await ChangeDateFormatFront(item.SerpTitle, item.SerpDescription, item.Subtitle, item.Paragraph, item.Section2Paragraph, item.Title, item.LanguageId);
                    item.SerpTitle = YM.SerpTitle;
                    item.SerpDescription = YM.SerpDescription;
                    item.Subtitle = YM.Subtitle;
                    item.Title = YM.Title;
                    item.Paragraph = YM.PageTitle;
                    item.Section2Paragraph = YM.Content;
                    //There is a chance that we also need item.Paragraph
                }
            }

            return aboutSettings;
        }

        public async Task<AboutSettingsODTO> EditAboutSettings(AboutSettingsIDTO aboutSettingsIDTO)
        {
            var aboutSettings = _mapper.Map<AboutSettings>(aboutSettingsIDTO);
            aboutSettings.SerpId = aboutSettings.SerpId != 0 ? aboutSettings.SerpId : null;


            _context.Entry(aboutSettings).State = EntityState.Modified;
            await SaveContextChangesAsync();

            var serp = new Serp
            {
                SerpTitle = aboutSettingsIDTO.SerpTitle,
                SerpDescription = aboutSettingsIDTO.SerpDescription,
                Subtitle = aboutSettingsIDTO.Subtitle,
                DataTypeId = ABOUT_SETTINGS_TYPEID,
                TableId = aboutSettingsIDTO.AboutSettingsId
            };

            YearMonthODTO YM = new YearMonthODTO();
            YM = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, aboutSettings.Paragraph, aboutSettings.Section2Paragraph, aboutSettings.Title);
            serp.SerpTitle = YM.SerpTitle;
            serp.SerpDescription = YM.SerpDescription;
            serp.Subtitle = YM.Subtitle;
            aboutSettings.Paragraph = YM.PageTitle;
            aboutSettings.Section2Paragraph = YM.Content;
            aboutSettings.Title = YM.Title;

            _context.Serps.Add(serp);
            await SaveContextChangesAsync();

            aboutSettings.SerpId = serp.SerpId;

            _context.Entry(aboutSettings).State = EntityState.Modified;

            await SaveContextChangesAsync();

            var settAttr = new SettingsAttribute();
            if (aboutSettingsIDTO.SettingsAttributes != null)
            {
                foreach (var item in aboutSettingsIDTO.SettingsAttributes)
                {
                    settAttr = new SettingsAttribute
                    {
                        SettingsAttributeId = item.SettingsAttributeId,
                        DataTypeId = ABOUT_SETTINGS_TYPEID,
                        SettingsDataTypeId = item.SettingsDataTypeId,
                        LanguageId = item.LanguageId,
                        Value = item.Value,
                        Index = item.Index,
                        UrlTableId = null,
                    };
                    var urlId = await _context.UrlTables.Where(x => x.URL.ToLower() == settAttr.Value && x.DataTypeId == settAttr.DataTypeId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                    settAttr.UrlTableId = settAttr.Value != null && urlId != 0 ? urlId : null;
                    _context.Entry(settAttr).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                    if (settAttr.UrlTableId != null)
                    {
                        if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID))
                        {
                            settAttr.Value = null;
                            await SaveContextChangesAsync();
                        }
                        else
                        {
                            settAttr.UrlTableId = null;
                            await SaveContextChangesAsync();
                        }
                    }
                    else if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                    {
                        var url = new UrlTable
                        {
                            DataTypeId = settAttr.DataTypeId,
                            URL = settAttr.Value,
                            TableId = settAttr.SettingsAttributeId,
                        };
                        _context.UrlTables.Add(url);
                        await SaveContextChangesAsync();
                        settAttr.UrlTableId = url.UrlTableId;
                        settAttr.Value = null;
                        await SaveContextChangesAsync();
                    }
                }
            }

            return await GetAboutSettingsById(aboutSettings.AboutSettingsId);
        }

        public async Task<AboutSettingsODTO> AddAboutSettings(AboutSettingsIDTO aboutSettingsIDTO)
        {
            var aboutSettings = _mapper.Map<AboutSettings>(aboutSettingsIDTO);

            aboutSettings.AboutSettingsId = 0;
            aboutSettings.SerpId = aboutSettings.SerpId != 0 ? aboutSettings.SerpId : null;

            _context.AboutSettings.Add(aboutSettings);

            await SaveContextChangesAsync();

            var serp = new Serp
            {
                SerpTitle = aboutSettingsIDTO.SerpTitle,
                SerpDescription = aboutSettingsIDTO.SerpDescription,
                Subtitle = aboutSettingsIDTO.Subtitle,
                DataTypeId = ABOUT_SETTINGS_TYPEID,
                TableId = aboutSettingsIDTO.AboutSettingsId
            };
            YearMonthODTO YM = new YearMonthODTO();
            YM = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, aboutSettings.Paragraph, aboutSettings.Section2Paragraph, aboutSettings.Title);
            serp.SerpTitle = YM.SerpTitle;
            serp.SerpDescription = YM.SerpDescription;
            serp.Subtitle = YM.Subtitle;
            aboutSettings.Paragraph = YM.PageTitle;
            aboutSettings.Section2Paragraph = YM.Content;
            aboutSettings.Title = YM.Title;

            _context.Serps.Add(serp);
            await SaveContextChangesAsync();

            aboutSettings.SerpId = serp.SerpId;
            await SaveContextChangesAsync();

            if (aboutSettingsIDTO.SettingsAttributes != null)
            {
                SettingsAttribute settAtr = new SettingsAttribute();
                foreach (var item in aboutSettingsIDTO.SettingsAttributes)
                {
                    settAtr = new SettingsAttribute
                    {
                        DataTypeId = item.DataTypeId,
                        SettingsDataTypeId = item.SettingsDataTypeId,
                        LanguageId = item.LanguageId,
                        Value = item.Value,
                        Index = item.Index,
                        UrlTableId = null,
                    };
                    var settAtrReal = await _context.SettingsAttributes.Where(x => x.DataTypeId == item.DataTypeId && x.SettingsDataTypeId == item.SettingsDataTypeId
                    && x.LanguageId == item.LanguageId && x.Value == item.Value && x.Index == item.Index && x.UrlTableId == item.UrlTableId).SingleOrDefaultAsync();

                    if (settAtrReal == null)
                    {
                        _context.SettingsAttributes.Add(settAtr);
                        await SaveContextChangesAsync();
                    }
                    else
                    {
                        _context.Entry(settAtr).State = EntityState.Modified;
                        await SaveContextChangesAsync();
                    }
                }
            }

            return await GetAboutSettingsById(aboutSettings.AboutSettingsId);
        }

        public async Task<AboutSettingsODTO> DeleteAboutSettings(int id)
        {
            var aboutSettings = await _context.AboutSettings.FindAsync(id);
            if (aboutSettings == null) return null;

            var aboutUrl = await _context.UrlTables.Where(x => x.TableId == aboutSettings.AboutSettingsId && x.DataTypeId == ABOUT_SETTINGS_TYPEID).ToListAsync();
            var aboutSerp = await _context.Serps.Where(x => x.TableId == aboutSettings.AboutSettingsId && x.DataTypeId == ABOUT_SETTINGS_TYPEID).ToListAsync();
            var aboutAttr = await _context.SettingsAttributes.Where(x => x.LanguageId == aboutSettings.LanguageId && x.DataTypeId == ABOUT_SETTINGS_TYPEID).ToListAsync();

            var aboutSettingsODTO = await GetAboutSettingsById(id);
            _context.AboutSettings.Remove(aboutSettings);
            await SaveContextChangesAsync();

            if (aboutUrl != null)
            {
                foreach (var item in aboutUrl)
                {
                    _context.UrlTables.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            if (aboutSerp != null)
            {
                foreach (var item in aboutSerp)
                {
                    _context.Serps.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            if (aboutAttr != null)
            {
                foreach (var item in aboutAttr)
                {
                    var x = await _context.UrlTables.Where(x => x.UrlTableId == item.UrlTableId).FirstOrDefaultAsync();
                    _context.SettingsAttributes.Remove(item);
                    await SaveContextChangesAsync();
                    if (x != null)
                    {
                        _context.UrlTables.Remove(x);
                        await SaveContextChangesAsync();
                    }
                }
            }

            return aboutSettingsODTO;
        }

        #endregion AboutSettings

        #region SettingsAttribute

        private IQueryable<SettingsAttribute> GetSettingsAttribute(int id, int langId, int datatypeId)
        {
            return from x in _context.SettingsAttributes
                   .Include(x => x.Url)
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

        public async Task<List<SettingsAttributeODTO>> EditSettingsAttribute(List<SettingsAttributeIDTO> settingsAttributeIDTO)
        {
            var settingsAttribute = settingsAttributeIDTO.Select(x => _mapper.Map<SettingsAttribute>(x)).ToList();
            YearMonthODTO ym;
            foreach (var settAttr in settingsAttribute)
            {
                var urlId = await _context.UrlTables.Where(x => x.URL.ToLower() == settAttr.Value && x.DataTypeId == settAttr.DataTypeId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                settAttr.UrlTableId = settAttr.Value != null && urlId != 0 ? urlId : null;

                ym = new YearMonthODTO();
                ym = await EditDate(null, null, null, null, settAttr.Value, null);
                settAttr.Value = ym.Content;

                _context.Entry(settAttr).State = EntityState.Modified;
                await SaveContextChangesAsync();
                if (settAttr.UrlTableId != null)
                {
                    settAttr.Value = null;
                    await SaveContextChangesAsync();
                }
                else if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                {
                    var url = new UrlTable
                    {
                        DataTypeId = settAttr.DataTypeId,
                        URL = settAttr.Value,
                        TableId = settAttr.SettingsAttributeId,
                    };
                    _context.UrlTables.Add(url);
                    await SaveContextChangesAsync();
                    settAttr.UrlTableId = url.UrlTableId;
                    settAttr.Value = null;
                    await SaveContextChangesAsync();
                }
            }
            await SaveContextChangesAsync();

            return settingsAttribute.Select(x => _mapper.Map<SettingsAttributeODTO>(x)).ToList();
        }

        public async Task<List<SettingsAttributeODTO>> AddSettingsAttribute(List<SettingsAttributeIDTO> settingsAttributeIDTO)
        {
            var settingsAttribute = settingsAttributeIDTO.Select(x => _mapper.Map<SettingsAttribute>(x)).ToList();
            YearMonthODTO ym;
            foreach (var settAttr in settingsAttribute)
            {
                settAttr.SettingsAttributeId = 0;
                var urlId = await _context.UrlTables.Where(x => x.URL.ToLower() == settAttr.Value && x.DataTypeId == settAttr.DataTypeId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                settAttr.UrlTableId = settAttr.Value != null && urlId != 0 ? urlId : null;
                settAttr.Value = settAttr.Value != null ? settAttr.Value : null;

                ym = new YearMonthODTO();
                ym = await EditDate(null, null, null, null, settAttr.Value, null);
                settAttr.Value = ym.Content;

                _context.SettingsAttributes.Add(settAttr);
                await SaveContextChangesAsync();
                if (settAttr.UrlTableId != null)
                {
                    settAttr.Value = null;
                    await SaveContextChangesAsync();
                }
                else if ((settAttr.SettingsDataTypeId == REVIEW_ROUTE_TYPEID || settAttr.SettingsDataTypeId == A_ITEM_LINK_TYPEID || settAttr.SettingsDataTypeId == P_ITEM_LINK_TYPEID) && (settAttr.Value != null))
                {
                    var url = new UrlTable
                    {
                        DataTypeId = settAttr.DataTypeId,
                        URL = settAttr.Value,
                        TableId = settAttr.SettingsAttributeId,
                    };
                    _context.UrlTables.Add(url);
                    await SaveContextChangesAsync();
                    settAttr.UrlTableId = url.UrlTableId;
                    settAttr.Value = null;
                    await SaveContextChangesAsync();
                }
            }

            return settingsAttribute.Select(x => _mapper.Map<SettingsAttributeODTO>(x)).ToList();
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

        #region Blog

        private IQueryable<BlogODTO> GetBlog(int id, int languageId, int categoryId, string blogName)
        {
            return from x in _context.Blogs
                   .Include(x => x.Language)
                   .Include(x => x.Category)
                   .Include(x => x.Serp)
                   where (id == 0 || x.BlogId == id)
                   && (languageId == 0 || x.LanguageId == languageId)
                   && (categoryId == 0 || x.CategoryId == categoryId)
                   && (string.IsNullOrEmpty(blogName) || x.Name.StartsWith(blogName))
                   select _mapper.Map<BlogODTO>(x);
        }

        public async Task<BlogODTO> GetBlogFull(int id)
        {
            var gu = await _context.UrlLanguages.Where(x => x.TableID == id && x.DataTypeId == 43).Select(x => x.GUID).ToListAsync();

            return await (from x in _context.Blogs
                   .Include(x => x.Language)
                   .Include(x => x.Category)
                   .Include(x => x.Serp)
                          where (id == 0 || x.BlogId == id)
                          select new BlogODTO
                          {
                              BlogId = x.BlogId,
                              Name = x.Name,
                              SerpId = x.SerpId,
                              SerpDescription = x.Serp.SerpDescription,
                              SerpTitle = x.Serp.SerpTitle,
                              Subtitle = x.Serp.Subtitle,
                              SelectedPopularArticle = x.SelectedPopularArticle,
                              SelectedPopularArticles = null,
                              CategoryId = x.CategoryId,
                              CategoryName = x.Category.CategoryName,
                              AuthorId = x.AuthorId,
                              PageTitle = x.PageTitle,
                              Excerpt = x.Excerpt,
                              UpdatedDate = DateTime.Now,
                              RouteName = null,
                              FeaturedImage = x.FeaturedImage,
                              UO = (from y in _context.UrlLanguages
                                    where (gu.Contains(y.GUID))
                                    select _mapper.Map<UrlLanguagesODTO>(y)).ToList(),
                          }).SingleOrDefaultAsync();
        }

        private IQueryable<AuthorODTO> GetAuthors(int languageId)
        {
            var blogs = from x in _context.Blogs
                   .Include(x => x.Language)
                        where (languageId == 0 || x.LanguageId == languageId)
                        select _mapper.Map<BlogODTO>(x);
            var blogsIdList = blogs.Select(x => x.AuthorId).ToList();
            return _context.Authors.Include(x => x.Language).Where(x => blogsIdList.Contains(x.AuthorID)).Select(x => _mapper.Map<AuthorODTO>(x));
        }

        public async Task<BlogODTO> GetBlogById(int id)
        {
            var blog = await GetBlog(id, 0, 0, null).AsNoTracking().SingleOrDefaultAsync();
            if (blog.SerpId != null)
            {
                var serp = (await GetSerp((int)blog.SerpId, 0).AsNoTracking().SingleOrDefaultAsync());
                blog.SerpTitle = serp.SerpTitle;
                blog.Subtitle = serp.Subtitle;
                blog.SerpDescription = serp.SerpDescription;
            }
            if (blog.SelectedPopularArticle != null && blog.SelectedPopularArticle != "string")
            {
                blog.SelectedPopularArticles = blog.SelectedPopularArticle.Split(",").Select(x => Convert.ToInt32(x)).ToArray();
            }

            YearMonthODTO ym = new YearMonthODTO();
            ym = await ChangeDateFormatAdmin(blog.SerpTitle, blog.SerpDescription, blog.Subtitle, blog.PageTitle, blog.Content, blog.Excerpt);
            blog.SerpTitle = ym.SerpTitle;
            blog.SerpDescription = ym.SerpDescription;
            blog.Subtitle = ym.Subtitle;
            blog.PageTitle = ym.PageTitle;
            blog.Content = ym.Content;
            blog.Excerpt = ym.Title;
            return blog;
        }

        public async Task<BlogODTO> GetBlogByName(string blogName)
        {
            return await GetBlog(0, 0, 0, blogName).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<BlogODTO>> GetBlogsByLang(int languageId, string UseCase)
        {
            //return await GetBlog(0, languageId, 0, null).AsNoTracking().ToListAsync();
            var blog = await _context.Blogs.Include(x => x.Serp).Include(x => x.Category).Where(x => x.LanguageId == languageId).ToListAsync();
            var blogs = new List<BlogODTO>();
            foreach (var item in blog)
            {
                var route = await _context.Routes.Where(x => x.LanguageId == languageId && x.DataTypeId == BLOG_TYPEID && x.TableId == item.BlogId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                var url = await _context.UrlTables.Where(x => x.UrlTableId == route).Select(x => x.URL).FirstOrDefaultAsync();

                var data = new BlogODTO()
                {
                    BlogId = item.BlogId,
                    Name = item.Name,
                    LanguageId = item.LanguageId,
                    SerpId = item.SerpId != null ? item.SerpId : null,
                    SerpTitle = item.SerpId != null ? item.Serp.SerpTitle : null,
                    SerpDescription = item.SerpId != null ? item.Serp.SerpDescription : null,
                    Subtitle = item.SerpId != null ? item.Serp.Subtitle : null,
                    Content = item.Content,
                    RouteName = url,
                    CategoryId = item.CategoryId != null ? item.CategoryId : null,
                    CategoryName = item.CategoryId != null ? item.Category.CategoryName : null,
                    AuthorId = item.AuthorId != null ? item.AuthorId : null,
                    PageTitle = item.PageTitle,
                    Excerpt = item.Excerpt,
                    UpdatedDate = item.UpdatedDate,
                    FeaturedImage = item.FeaturedImage
                };
                blogs.Add(data);
                YearMonthODTO ym;
                if (UseCase == "Dashboard")
                {
                    foreach (var item1 in blogs)
                    {
                        ym = new YearMonthODTO();
                        ym = await ChangeDateFormatAdmin(item1.SerpTitle, item1.SerpDescription, item1.Subtitle, item1.PageTitle, item1.Content, item1.Excerpt);
                        item1.SerpTitle = ym.SerpTitle;
                        item1.SerpDescription = ym.SerpDescription;
                        item1.Subtitle = ym.Subtitle;
                        item1.Content = ym.Content;
                        item1.PageTitle = ym.PageTitle;
                        item.Excerpt = ym.Title;
                    }
                }
                else
                {
                    foreach (var item1 in blogs)
                    {
                        ym = new YearMonthODTO();
                        ym = await ChangeDateFormatFront(item1.SerpTitle, item1.SerpDescription, item1.Subtitle, item1.PageTitle, item1.Content, item1.Excerpt, item1.LanguageId);
                        item1.SerpTitle = ym.SerpTitle;
                        item1.SerpDescription = ym.SerpDescription;
                        item1.Subtitle = ym.Subtitle;
                        item1.Content = ym.Content;
                        item1.PageTitle = ym.PageTitle;
                        item1.Excerpt = ym.Title;
                    }
                }
            }
            return blogs;
        }

        public async Task<GetBlogsByRouteODTO> GetBlogsByRoute(string route, int langid)
        {
            var url = await _context.UrlTables.Where(x => x.URL.ToLower() == route.ToLower() && x.DataTypeId == ROUTES_TYPEID).Select(x => x.UrlTableId).FirstOrDefaultAsync();
            var routes = await _context.Routes.Where(x => x.DataTypeId == BLOG_TYPEID && x.UrlTableId == url && x.LanguageId == langid).Select(x => x.TableId).FirstOrDefaultAsync();
            var blog = await _context.Blogs.Include(x => x.Serp).Include(x => x.Category).Where(x => x.BlogId == routes).FirstOrDefaultAsync();
            var blogs = new List<BlogContetntODTO>();
            if (blog.SelectedPopularArticle != null)
            {
                var popularArticle = blog.SelectedPopularArticle.Split(",").Select(x => Convert.ToInt32(x)).ToArray();
                foreach (var item in popularArticle)
                {
                    var x = await _context.Blogs.Include(x => x.Serp).Include(x => x.Category).Where(x => x.BlogId == item).FirstOrDefaultAsync();
                    if (x != null)
                        blogs.Add(_mapper.Map<BlogContetntODTO>(x));
                }
                foreach (var item in blogs)
                {
                    var r = await _context.Routes.Where(x => x.LanguageId == item.LanguageId && x.DataTypeId == BLOG_TYPEID && x.TableId == item.BlogId).Select(x => x.UrlTableId).FirstOrDefaultAsync();
                    var u = await _context.UrlTables.Where(x => x.UrlTableId == r).Select(x => x.URL).FirstOrDefaultAsync();
                    item.RouteName = u;
                }
            }

            var retval = new GetBlogsByRouteODTO
            {
                BlogId = blog.BlogId,
                Name = blog.Name,
                LanguageId = blog.LanguageId,
                SerpId = blog.SerpId,
                SerpTitle = blog.Serp.SerpTitle,
                SerpDescription = blog.Serp.SerpDescription,
                Subtitle = blog.Serp.Subtitle,
                Content = blog.Content,
                SelectedPopularArticle = blogs,
                CategoryId = blog.CategoryId,
                CategoryName = blog.Category.CategoryName,
                AuthorId = blog.AuthorId,
                PageTitle = blog.PageTitle,
                Excerpt = blog.Excerpt,
                UpdatedDate = blog.UpdatedDate,
                FeaturedImage = blog.FeaturedImage
            };

            YearMonthODTO ym1 = new YearMonthODTO();
            ym1 = await ChangeDateFormatFront(retval.SerpTitle, retval.SerpDescription, retval.Subtitle, retval.PageTitle, retval.Content, null, retval.LanguageId);
            retval.SerpTitle = ym1.SerpTitle;
            retval.SerpDescription = ym1.SerpDescription;
            retval.Subtitle = ym1.Subtitle;
            retval.PageTitle = ym1.PageTitle;
            retval.Content = ym1.Content;
            return retval;
        }

        public async Task<List<BlogODTO>> GetBlogsByCategory(int categoryId)
        {
            return await GetBlog(0, 0, categoryId, null).AsNoTracking().ToListAsync();
        }

        public async Task<List<AuthorODTO>> GetAuthorsByLanguageId(int languageId)
        {
            return await GetAuthors(languageId).AsNoTracking().ToListAsync();
        }

        public async Task<GetItemContentODTO> GetBlogItemContent(int? id)
        {
            var page = await _context.Blogs.FirstOrDefaultAsync(e => e.BlogId == id);

            var retVal = new GetItemContentODTO
            {
                PageId = page.BlogId,
                Content = page.Content,
            };
            YearMonthODTO ym1 = new YearMonthODTO();
            ym1 = await ChangeDateFormatAdmin(null, null, null, null, retVal.Content, null);
            retVal.Content = ym1.Content;
            return retVal;
        }

        public async Task<BlogODTO> EditBlog(BlogIDTO blogIDTO)
        {
            try
            {
                var blog = _mapper.Map<Blog>(blogIDTO);
                var content = await _context.Blogs.Where(x => x.BlogId == blogIDTO.BlogId).Select(x => x.Content).FirstOrDefaultAsync();
                blog.UpdatedDate = DateTime.Now;
                blog.LanguageId = blog.LanguageId == 0 ? null : blog.LanguageId;
                blog.CategoryId = blog.CategoryId == 0 ? null : blog.CategoryId;
                blog.AuthorId = blog.AuthorId == 0 ? null : blog.AuthorId;
                blog.SerpId = blog.SerpId == 0 ? null : blog.SerpId;
                blog.Content = content;
                blog.SelectedPopularArticle = blog.SelectedPopularArticle == null || blog.SelectedPopularArticle == "" ? null : blog.SelectedPopularArticle;
                _context.Entry(blog).State = EntityState.Modified;
                await SaveContextChangesAsync();

                if (blog.SerpId == null)
                {
                    var serp = new Serp
                    {
                        SerpTitle = blogIDTO.SerpTitle,
                        SerpDescription = blogIDTO.SerpDescription,
                        Subtitle = blogIDTO.Subtitle,
                        DataTypeId = BLOG_TYPEID,
                        TableId = blog.BlogId
                    };

                    YearMonthODTO ym = new YearMonthODTO();
                    ym = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, null);
                    serp.SerpTitle = ym.SerpTitle;
                    serp.SerpDescription = ym.SerpDescription;
                    serp.Subtitle = ym.Subtitle;
                    //_context.Entry(serp).State = EntityState.Modified;
                    _context.Serps.Add(serp);
                    await SaveContextChangesAsync();

                    blog.SerpId = serp.SerpId;
                    await SaveContextChangesAsync();
                }
                YearMonthODTO ym1 = new YearMonthODTO();
                ym1 = await EditDate(null, null, null, blog.PageTitle, blog.Content, blog.Excerpt);
                blog.PageTitle = ym1.PageTitle;
                blog.Content = ym1.Content;
                blog.Excerpt = ym1.Title;
                _context.Entry(blog).State = EntityState.Modified;
                await SaveContextChangesAsync();
                return await GetBlogById(blog.BlogId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<BlogODTO> AddBlog(BlogIDTO blogIDTO)
        {
            var blog = _mapper.Map<Blog>(blogIDTO);

            blog.BlogId = 0;
            blog.SerpId = blog.SerpId == 0 ? null : blog.SerpId;
            blog.LanguageId = blog.LanguageId == 0 ? null : blog.LanguageId;
            blog.CategoryId = blog.CategoryId == 0 ? null : blog.CategoryId;
            blog.AuthorId = blog.AuthorId == 0 ? null : blog.AuthorId;
            blog.SelectedPopularArticle = blog.SelectedPopularArticle == null || blog.SelectedPopularArticle == "" ? null : blog.SelectedPopularArticle;
            blog.UpdatedDate = DateTime.Now;
            _context.Blogs.Add(blog);
            await SaveContextChangesAsync();

            var serp = new Serp
            {
                SerpTitle = blogIDTO.SerpTitle,
                SerpDescription = blogIDTO.SerpDescription,
                Subtitle = blogIDTO.Subtitle,
                DataTypeId = BLOG_TYPEID,
                TableId = blog.BlogId
            };
            _context.Serps.Add(serp);

            YearMonthODTO ym = new YearMonthODTO();
            ym = await EditDate(serp.SerpTitle, serp.SerpDescription, serp.Subtitle, null, null, null);
            serp.SerpTitle = ym.SerpTitle;
            serp.SerpDescription = ym.SerpDescription;
            serp.Subtitle = ym.Subtitle;
            await SaveContextChangesAsync();

            blog.SerpId = serp.SerpId;

            YearMonthODTO ym1 = new YearMonthODTO();
            ym1 = await EditDate(null, null, null, blog.PageTitle, blog.Content, null);
            blog.PageTitle = ym1.PageTitle;
            blog.Content = ym1.Content;
            _context.Entry(blog).State = EntityState.Modified;
            await SaveContextChangesAsync();

            return await GetBlogFull(blog.BlogId);
        }

        public async Task<BlogODTO> EditBlogContent(PutContentIDTO contentIDTO)
        {
            var blog = await _context.Blogs.Where(x => x.BlogId == contentIDTO.Id).FirstOrDefaultAsync();
            blog.Content = contentIDTO.Content;
            blog.SelectedPopularArticle = blog.SelectedPopularArticle == null || blog.SelectedPopularArticle == "" ? null : blog.SelectedPopularArticle;
            _context.Entry(blog).State = EntityState.Modified;
            await SaveContextChangesAsync();
            return await GetBlogById(blog.BlogId);
        }

        public async Task<BlogODTO> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return null;

            var faqTitles = await _context.FaqTitles.Where(x => x.BlogId == blog.BlogId).ToListAsync();

            foreach (var item in faqTitles)
            {
                var x = await _context.FaqLists.Where(x => x.FaqTitleId == item.FaqTitleId).ToListAsync();
                foreach (var item2 in x)
                {
                    _context.FaqLists.Remove(item2);
                    await SaveContextChangesAsync();
                }
            }
            foreach (var item in faqTitles)
            {
                _context.FaqTitles.Remove(item);
                await SaveContextChangesAsync();
            }

            var blogODTO = await GetBlogById(id);
            _context.Blogs.Remove(blog);
            await SaveContextChangesAsync();
            return blogODTO;
        }

        #endregion Blog

        #region Categories

        private IQueryable<CategoryODTO> GetCategories(int id, int languageId)
        {
            return from x in _context.Categories
                   .Include(x => x.Language)
                   where (id == 0 || x.CategoryId == id)
                   && (languageId == 0 || x.LanguageId == languageId)
                   select _mapper.Map<CategoryODTO>(x);
        }

        public async Task<List<CategoryODTO>> GetCategoriesByLanguageId(int languageId)
        {
            return await GetCategories(0, languageId).AsNoTracking().ToListAsync();
        }

        public async Task<CategoryODTO> GetCategoryById(int id)
        {
            return await GetCategories(id, 0).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<CategoryODTO> EditCategory(CategoryIDTO categoryIDTO)
        {
            var category = _mapper.Map<Category>(categoryIDTO);

            _context.Entry(category).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetCategoryById(category.CategoryId);
        }

        public async Task<CategoryODTO> AddCategory(CategoryIDTO categoryIDTO)
        {
            var category = _mapper.Map<Category>(categoryIDTO);

            category.CategoryId = 0;
            _context.Categories.Add(category);

            await SaveContextChangesAsync();

            return await GetCategoryById(category.CategoryId);
        }

        public async Task<CategoryODTO> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return null;

            var categoryODTO = await GetCategoryById(id);
            _context.Categories.Remove(category);
            await SaveContextChangesAsync();
            return categoryODTO;
        }

        #endregion Categories

        #region Roles

        private IQueryable<RoleODTO> GetRole(int id, string roleName)
        {
            return from x in _context.Roles
                   where (id == 0 || x.RoleId == id)
                   && (string.IsNullOrEmpty(roleName) || x.RoleName.StartsWith(roleName))
                   select _mapper.Map<RoleODTO>(x);
        }

        public async Task<RoleODTO> GetRoleById(int id)
        {
            return await GetRole(id, null).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<RoleODTO>> GetAllRoles()
        {
            return await GetRole(0, null).AsNoTracking().ToListAsync();
        }

        public async Task<RoleODTO> EditRole(RoleIDTO roleIDTO)
        {
            var role = _mapper.Map<Role>(roleIDTO);

            _context.Entry(role).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetRoleById(role.RoleId);
        }

        public async Task<RoleODTO> AddRole(RoleIDTO roleIDTO)
        {
            var role = _mapper.Map<Role>(roleIDTO);
            role.RoleId = 0;
            _context.Roles.Add(role);

            await SaveContextChangesAsync();

            return await GetRoleById(role.RoleId);
        }

        public async Task<RoleODTO> DeleteRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null) return null;

            var roleODTO = await GetRoleById(id);
            _context.Roles.Remove(role);
            await SaveContextChangesAsync();
            return roleODTO;
        }

        #endregion Roles

        #region Permissions

        private IQueryable<Permission> GetPermissions(int id, int langId, int roleId, int userId, int dataTypeId)
        {
            return from x in _context.Permissions
                   where (id == 0 || x.PermissionId == id)
                   && (langId == 0 || x.LanguageId == langId)
                   && (roleId == 0 || x.RoleId == roleId)
                   && (userId == 0 || x.UserId == userId)
                   && (dataTypeId == 0 || x.UserId == dataTypeId)
                   select x;
        }

        public async Task<PermissionODTO> GetPermissionsById(int id)
        {
            return await _mapper.ProjectTo<PermissionODTO>(GetPermissions(id, 0, 0, 0, 0)).AsNoTracking().SingleOrDefaultAsync();
        }

        public async Task<List<PermissionODTO>> GetPermissionsByLangId(int langId)
        {
            return await _mapper.ProjectTo<PermissionODTO>(GetPermissions(0, langId, 0, 0, 0)).ToListAsync();
        }

        public async Task<List<PermissionODTO>> GetPermissionsByRoleId(int roleId)
        {
            return await _mapper.ProjectTo<PermissionODTO>(GetPermissions(0, 0, roleId, 0, 0)).ToListAsync();
        }

        public async Task<List<PermissionODTO>> GetPermissionsByUserId(int userId, int langId)
        {
            return await _mapper.ProjectTo<PermissionODTO>(GetPermissions(0, langId, 0, userId, 0)).ToListAsync();
        }

        public async Task<List<PermissionODTO>> GetPermissionsByDataTypeId(int dataTypeId)
        {
            return await _mapper.ProjectTo<PermissionODTO>(GetPermissions(0, 0, 0, 0, dataTypeId)).ToListAsync();
        }

        public async Task<List<PermissionODTO>> EditPermissions(List<PermissionIDTO> permissionIDTO)
        {
            var permission = permissionIDTO.Select(x => _mapper.Map<Permission>(x)).ToList();

            foreach (var per in permission)
            {
                _context.Entry(per).State = EntityState.Modified;
            }
            await SaveContextChangesAsync();

            return permission.Select(x => _mapper.Map<PermissionODTO>(x)).ToList();
        }

        public async Task<List<PermissionODTO>> AddPermissions(List<PermissionIDTO> permissionIDTO)
        {
            var permission = permissionIDTO.Select(x => _mapper.Map<Permission>(x)).ToList();

            foreach (var per in permission)
            {
                _context.Permissions.Add(per);
            }
            await SaveContextChangesAsync();

            return permission.Select(x => _mapper.Map<PermissionODTO>(x)).ToList();
        }

        public async Task<PermissionODTO> DeletePermissions(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission == null) return null;

            var permissionODTO = await GetPermissionsById(id);
            _context.Permissions.Remove(permission);
            await SaveContextChangesAsync();
            return permissionODTO;
        }

        #endregion Permissions

        #region Authors

        private IQueryable<AuthorODTO> GetAuthor(int id, int langId)
        {
            return from x in _context.Authors
                   .Include(x => x.Language)
                   where (id == 0 || x.AuthorID == id)
                   && (langId == 0 || x.LanguageId == langId)
                   select _mapper.Map<AuthorODTO>(x);
        }

        public async Task<AuthorODTO> GetAuthorById(int id)
        {
            return await GetAuthor(id, 0).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<AuthorODTO>> GetAllAuthors()
        {
            return await GetAuthor(0, 0).AsNoTracking().ToListAsync();
        }

        public async Task<List<AuthorODTO>> GetAllAuthorsByLangID(int langId)
        {
            return await GetAuthor(0, langId).AsNoTracking().ToListAsync();
        }

        public async Task<AuthorODTO> EditAuthor(AuthorIDTO authorIDTO)
        {
            var author = _mapper.Map<Author>(authorIDTO);

            _context.Entry(author).State = EntityState.Modified;

            await SaveContextChangesAsync();

            return await GetAuthorById(author.AuthorID);
        }

        public async Task<AuthorODTO> AddAuthor(AuthorIDTO authorIDTO)
        {
            var author = _mapper.Map<Author>(authorIDTO);
            author.AuthorID = 0;
            _context.Authors.Add(author);

            await SaveContextChangesAsync();

            return await GetAuthorById(author.AuthorID);
        }

        public async Task<AuthorODTO> DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return null;

            var blog = await _context.Blogs.Where(x => x.AuthorId == id).ToListAsync();
            if (blog != null)
            {
                foreach (var item in blog)
                {
                    item.AuthorId = 12;
                    _context.Entry(item).State = EntityState.Modified;
                    await SaveContextChangesAsync();
                }
            }

            var authorODTO = await GetAuthorById(id);
            _context.Authors.Remove(author);
            await SaveContextChangesAsync();
            return authorODTO;
        }

        #endregion Authors

        #region ImageInfo

        private IQueryable<ImagesInfoODTO> GetImageInfo(int id)
        {
            return from x in _context.ImagesInfos
                   .Include(x => x.UrlTable)
                   where (id == 0 || x.ImageId == id)
                   select _mapper.Map<ImagesInfoODTO>(x);
        }

        public async Task<ImagesInfoODTO> GetImageInfoByAWS(string aws)
        {
            var url = await _context.UrlTables.Where(x => x.URL.ToLower() == aws.ToLower()).Select(x => x.UrlTableId).FirstOrDefaultAsync();
            return await _context.ImagesInfos.Include(x => x.UrlTable).Where(x => x.AwsUrl == url).Select(x => _mapper.Map<ImagesInfoODTO>(x)).FirstOrDefaultAsync();
        }

        public async Task<ImagesInfoODTO> EditImageInfo(ImagesInfoIDTO imagesInfoIDTO)
        {
            var imageInfo = _mapper.Map<ImagesInfo>(imagesInfoIDTO);
            var Img = await _context.ImagesInfos.Where(x => x.ImageId == imageInfo.ImageId).AsNoTracking().SingleOrDefaultAsync();
            var url = new UrlTable();
            if (Img == null)
            {
                url.DataTypeId = IMAGE_INFO_TYPEID;
                url.URL = imagesInfoIDTO.Aws;
                _context.UrlTables.Add(url);
                await SaveContextChangesAsync();

                imageInfo.AwsUrl = url.UrlTableId;
            }
            else
            {
                imageInfo.AwsUrl = Img.AwsUrl;
                imageInfo.Size = Img.Size;
            }

            _context.Entry(imageInfo).State = EntityState.Modified;
            await SaveContextChangesAsync();
            url.TableId = imageInfo.ImageId;
            await SaveContextChangesAsync();

            return await GetImageInfo(imageInfo.ImageId).FirstOrDefaultAsync();
        }

        public async Task<ImagesInfoODTO> AddImageInfo(ImagesInfoIDTO imagesInfoIDTO)
        {
            var Img = await _context.ImagesInfos.Select(x => x.AwsUrl).ToListAsync();
            List<string> Lista = new List<string>();
            foreach (var item in Img)
            {
                var uros = await _context.UrlTables.Where(x => x.UrlTableId == item).Select(x => x.URL).SingleOrDefaultAsync();
                Lista.Add(uros);
            }
            foreach (var item1 in Lista)
            {
                if (item1 == imagesInfoIDTO.Aws)
                {
                    return null;
                }
            }

            var imageInfo = _mapper.Map<ImagesInfo>(imagesInfoIDTO);
            var url = new UrlTable
            {
                DataTypeId = IMAGE_INFO_TYPEID,
                URL = imagesInfoIDTO.Aws
            };
            _context.UrlTables.Add(url);
            await SaveContextChangesAsync();

            imageInfo.ImageId = 0;
            imageInfo.AwsUrl = url.UrlTableId;
            _context.ImagesInfos.Add(imageInfo);
            await SaveContextChangesAsync();

            url.TableId = imageInfo.ImageId;
            await SaveContextChangesAsync();
            return await GetImageInfo(imageInfo.ImageId).FirstOrDefaultAsync();
        }

        public async Task<ImagesInfoODTO> DeleteImageInfo(int id)
        {
            var imageInfo = await _context.ImagesInfos.FindAsync(id);
            if (imageInfo == null) return null;
            ImagesInfoODTO imageInfoODTO = GetImageInfo(id).FirstOrDefault();
            _context.ImagesInfos.Remove(imageInfo);
            await SaveContextChangesAsync();

            var url = await _context.UrlTables.Where(x => x.UrlTableId == imageInfo.AwsUrl).ToListAsync();
            foreach (var item in url)
            {
                imageInfo.AwsUrl = null;
                _context.UrlTables.Remove(item);
                await SaveContextChangesAsync();
            }
            return imageInfoODTO;
        }

        public async Task<List<ImagesInfoODTO>> DeleteImagesInfo(List<string> imagesInfoIDTO)
        {
            var imageInfos = imagesInfoIDTO.ToList();
            var data = new List<ImagesInfoODTO>();

            var urls = new List<UrlTable>();
            foreach (var item in imagesInfoIDTO)
            {
                var x = await _context.UrlTables.Where(x => x.URL == item && x.DataTypeId == IMAGE_INFO_TYPEID).FirstOrDefaultAsync();
                if (x != null)
                    urls.Add(x);
            }
            foreach (var item in urls)
            {
                var image = await _context.ImagesInfos.Where(x => x.ImageId == item.TableId && x.AwsUrl == item.UrlTableId).FirstOrDefaultAsync();

                if (image != null)
                {
                    data.Add(_mapper.Map<ImagesInfoODTO>(image));
                    _context.ImagesInfos.Remove(image);
                    await SaveContextChangesAsync();
                    _context.UrlTables.Remove(item);
                    await SaveContextChangesAsync();
                }
            }
            return data;
        }

        #endregion ImageInfo
    }
}