using MobileStore.Domain.Entities;
using MobileStore.Models;
using MobileStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobileStore.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly BasicServices _basicServices;

        public HomeController(BasicServices BasicServices) {
            _basicServices = BasicServices;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var news = _basicServices.GetAllPosts();
            List<PostModel> modelList = new List<PostModel>();
            foreach (var item in news) {
                PostModel model = new PostModel() {
                    Subject = item.Subject,
                    Content = item.Content,
                    CreateDate = item.CreateDate,
                    Author = item.User.Email
                };
                modelList.Add(model);
            }
            return View(modelList);
        }


        public ActionResult GetOEMPhones(int oemID = 0) {
            List<PhonesListModel> PhonesList;
            List<Phone> EntityPhones;
             if (oemID == 0) {
               EntityPhones =  _basicServices.GetAllPhones().ToList<Phone>();
            }
             else {
                EntityPhones = _basicServices.GetOEMPhones(oemID).ToList();
                ViewData["ID"] = oemID;
            }
            PhonesList = new List<PhonesListModel>();
            foreach (var item in EntityPhones) {
                PhonesListModel model = new PhonesListModel() {
                    Name = item.PhoneName,
                    Manufacturer = item.Manufacturer.Name,
                    Views = item.Views ?? 0, 
                    Rating = item.RatingTotal,
                    ID = item.ID
                };
                PhonesList.Add(model);
            }
            return View(PhonesList);
        }

        public ActionResult PhoneDetails(int id) {
            var phone = _basicServices.GetPhone(id, "Manufacturer");
            CreatePhoneModel model = ConvertToPhoneModel(phone);
            if (model != null) {
                _basicServices.AddView(phone);
            }
            return View(model);
        }

        public ActionResult PopularPhones() {
            var phones = _basicServices.GetPopularPhones();
            List<TopPhonesModel> TopPhones = new List<TopPhonesModel>();
            foreach (var item in phones) {
                TopPhonesModel topPhone = new TopPhonesModel() {
                    ID = item.ID,
                    Name = item.PhoneName,
                    Views = item.Views
                };
                TopPhones.Add(topPhone);
            }
            return PartialView(TopPhones);
        }

      
        public ActionResult OEMList() {
            var manufacturers = _basicServices.GetOEMS();
            List<ModelOEM> OEMS = new List<ModelOEM>();
            foreach (var item in manufacturers)
            {
                ModelOEM OEM = new ModelOEM()
                {
                    Name = item.Name,
                    ID = item.ID
                };
                OEMS.Add(OEM);
            }
            return PartialView(OEMS);
        }

        private CreatePhoneModel ConvertToPhoneModel(Phone Phone) {
            return new CreatePhoneModel
            {
                PhoneName = Phone.PhoneName,
                Model = Phone.Model,
                Resolution = Phone.Resolution,
                OS = Phone.OS,
                CPU = Phone.CPU,
                GPU = Phone.GPU,
                MainCamera = Phone.MainCamera,
                SecondaryCamera = Phone.SecondaryCamera,
                BatteryCapacity = Phone.BatteryCapacity,
                Price = Phone.Price,
                RealseDate = Phone.ReleaseDate,
                OEMID = Phone.OEMID
            };
        }
    }
}