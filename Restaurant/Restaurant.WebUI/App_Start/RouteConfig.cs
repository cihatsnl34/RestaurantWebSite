using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurant.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);
            #region Sayfalar
            routes.MapRoute(
               name: "Anasayfa",
               url: "",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "InsanKaynaklari",
               url: "insan-kaynaklari",
               defaults: new { controller = "Human", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Anasayfa2",
               url: "anasayfa",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
            name: "Hakkimizda",
            url: "hakkimizda",
            defaults: new { controller = "Hakkimizda", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "BilgiAl",
            url: "bilgi-al",
            defaults: new { controller = "BilgiAl", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "SirketPolitikamiz",
            url: "sirket-politikamiz",
            defaults: new { controller = "SirketPolitikamiz", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Vizyonumuz",
            url: "vizyonumuz",
            defaults: new { controller = "Vizyonumuz", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Misyonumuz",
            url: "misyonumuz",
            defaults: new { controller = "Misyonumuz", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "RestorantVeIs",
            url: "edt",
            defaults: new { controller = "RestorantVeIs", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "SıkcaSorulanSorular",
            url: "sss",
            defaults: new { controller = "SıkcaSorulanSorular", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "SaglikliBeslen",
            url: "saglikli-beslen",
            defaults: new { controller = "SaglikliBeslen", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Iletisim",
            url: "iletisim",
            defaults: new { controller = "Iletisim", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Urunler",
            url: "urunler",
            defaults: new { controller = "Urunler", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Kategori",
            url: "kategoriler",
            defaults: new { controller = "Kategori", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "UrunlerDetay",
            url: "urunler/{s}",
            defaults: new { controller = "UrunlerDetay", action = "Index", s = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "KategoriDetay",
            url: "kategoriler/{s}",
            defaults: new { controller = "KategoriDetay", action = "Index", s = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "HaberDetay",
            url: "haberler/{s}",
            defaults: new { controller = "HaberDetay", action = "Index", s = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Videolart",
            url: "videolar",
            defaults: new { controller = "Videolart", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Haber",
            url: "haber",
            defaults: new { controller = "Haberler", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "basinbiz",
            url: "basin-da-biz",
            defaults: new { controller = "BasinBiz", action = "Index", id = UrlParameter.Optional }
        );
            routes.MapRoute(
            name: "Basindabiz",
            url: "basin-da-biz/{a}",
            defaults: new { controller = "BasinBizDetay", action = "Index", id = UrlParameter.Optional }
        );
            #endregion
            #region PartialSayfalar
            routes.MapRoute(
                name: "PartialCategory",
                url: "PartialCategory",
                defaults: new { controller = "Home", action = "PartialCategory", id = UrlParameter.Optional }
            );
            routes.MapRoute(
              name: "PartialSlider",
              url: "PartialSlider",
              defaults: new { controller = "Home", action = "PartialSlider", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "PartialHeaderMenuList",
              url: "PartialHeaderMenuList",
              defaults: new { controller = "Home", action = "PartialHeaderMenuList", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "PartialVizyonumuzConstantValue",
              url: "PartialVizyonumuzConstantValue",
              defaults: new { controller = "Vizyonumuz", action = "PartialVizyonumuzConstantValue", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "PartialHeaderLezzetlerimizCateogryList",
              url: "PartialHeaderLezzetlerimizCateogryList",
              defaults: new { controller = "Home", action = "PartialHeaderLezzetlerimizCateogryList", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "PartialProduct",
                url: "PartialProduct",
                defaults: new { controller = "Home", action = "PartialProduct", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PartialMobileMenuList",
                url: "PartialMobileMenuList",
                defaults: new { controller = "Home", action = "PartialMobileMenuList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PartialSirketPolitikamizConstantValue",
                url: "PartialSirketPolitikamizConstantValue",
                defaults: new { controller = "SirketPolitikamiz", action = "PartialSirketPolitikamizConstantValue", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "PartialFooterMenuCategoryList",
                url: "PartialFooterMenuCategoryList",
                defaults: new { controller = "Home", action = "PartialFooterMenuCategoryList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialTabCategory",
                url: "PartialTabCategory",
                defaults: new { controller = "Home", action = "PartialTabCategory", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialMisyonumuzConstantValue",
                url: "PartialMisyonumuzConstantValue",
                defaults: new { controller = "Misyonumuz", action = "PartialMisyonumuzConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialHumanResources",
                url: "PartialHumanResources",
                defaults: new { controller = "Human", action = "PartialHumanResources", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialBannerHumanResourcers",
                url: "PartialBannerHumanResourcers",
                defaults: new { controller = "Human", action = "PartialBannerHumanResourcers", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialHeaderSaglikliBeslen",
                url: "PartialHeaderSaglikliBeslen",
                defaults: new { controller = "Home", action = "PartialHeaderSaglikliBeslen", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialConstantValue1",
                url: "PartialConstantValue1",
                defaults: new { controller = "Home", action = "PartialConstantValue1", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialAboutFooter",
                url: "PartialAboutFooter",
                defaults: new { controller = "Home", action = "PartialAboutFooter", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialBilgiAlConstantValue",
                url: "PartialBilgiAlConstantValue",
                defaults: new { controller = "BilgiAl", action = "PartialBilgiAlConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialHeaderBizdenHaberler",
                url: "PartialHeaderBizdenHaberler",
                defaults: new { controller = "Home", action = "PartialHeaderBizdenHaberler", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialConstantValue2",
                url: "PartialConstantValue2",
                defaults: new { controller = "Home", action = "PartialConstantValue2", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialConstantValue3",
                url: "PartialConstantValue3",
                defaults: new { controller = "Home", action = "PartialConstantValue3", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialMobileMenuCategoryList",
                url: "PartialMobileMenuCategoryList",
                defaults: new { controller = "Home", action = "PartialMobileMenuCategoryList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialContactLayout",
                url: "PartialContactLayout",
                defaults: new { controller = "Iletisim", action = "PartialContactLayout", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialContactInformation",
                url: "PartialContactInformation",
                defaults: new { controller = "BilgiAl", action = "PartialContactInformation", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialContactBanner",
                url: "PartialContactBanner",
                defaults: new { controller = "Iletisim", action = "PartialContactBanner", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialSocialMedia",
                url: "PartialSocialMedia",
                defaults: new { controller = "SosyalMedya", action = "PartialSocialMedia", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialProductConstantValue",
                url: "PartialProductConstantValue",
                defaults: new { controller = "Urunler", action = "PartialProductConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialNews",
                url: "PartialNews",
                defaults: new { controller = "Home", action = "PartialNews", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialVideoList",
                url: "PartialVideoList",
                defaults: new { controller = "Home", action = "PartialVideoList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialProductList",
                url: "PartialProductList",
                defaults: new { controller = "Home", action = "PartialProductList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialHakkimizdaConstantValue",
                url: "PartialHakkimizdaConstantValue",
                defaults: new { controller = "Hakkimizda", action = "PartialHakkimizdaConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialHaberDetayConstantValue",
                url: "PartialHaberDetayConstantValue",
                defaults: new { controller = "HaberDetay", action = "PartialHaberDetayConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialKategoriConstantValue",
                url: "PartialKategoriConstantValue",
                defaults: new { controller = "Kategori", action = "PartialKategoriConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialKategoriDetayConstantValue",
                url: "PartialKategoriDetayConstantValue",
                defaults: new { controller = "KategoriDetay", action = "PartialKategoriDetayConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialContactConstantValue",
                url: "PartialContactConstantValue",
                defaults: new { controller = "Iletisim", action = "PartialContactConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialRestaurantConstantValue",
                url: "PartialRestaurantConstantValue",
                defaults: new { controller = "RestorantVeIs", action = "PartialRestaurantConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialSaglikliConstantValue",
                url: "PartialSaglikliConstantValue",
                defaults: new { controller = "SaglikliBeslen", action = "PartialSaglikliConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialSSSConstantValue",
                url: "PartialSSSConstantValue",
                defaults: new { controller = "SıkcaSorulanSorular", action = "PartialSSSConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialProductDetayConstantValue",
                url: "PartialProductDetayConstantValue",
                defaults: new { controller = "UrunlerDetay", action = "PartialProductDetayConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialVideoConstantValue",
                url: "PartialVideoConstantValue",
                defaults: new { controller = "Videolart", action = "PartialVideoConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialContact",
                url: "PartialContact",
                defaults: new { controller = "Iletisim", action = "PartialContact", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialHaberlerConstantValue",
                url: "PartialHaberlerConstantValue",
                defaults: new { controller = "Haberler", action = "PartialHaberlerConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialRandomNewsList",
                url: "PartialRandomNewsList",
                defaults: new { controller = "HaberDetay", action = "PartialRandomNewsList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialBasindaBizConstantValue",
                url: "PartialBasindaBizConstantValue",
                defaults: new { controller = "BasinBiz", action = "PartialBasindaBizConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialBasindaBizDetayConstantValue",
                url: "PartialBasindaBizDetayConstantValue",
                defaults: new { controller = "BasinBizDetay", action = "PartialBasindaBizDetayConstantValue", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PartialFooterMenuList",
                url: "PartialFooterMenuList",
                defaults: new { controller = "Home", action = "PartialFooterMenuList", id = UrlParameter.Optional }
            );
            #endregion
            #region Hata Sayfası
            routes.MapRoute(
                name: "NotFound",
                url: "{*url}",
                defaults: new { controller = "Erorr", action = "NotFound" }
            );
            #endregion
        }
    }
}
