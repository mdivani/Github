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
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly AdminServices _adminServices;
        private readonly BasicServices _basicServices;

        public AdminController(AdminServices AdminServices, BasicServices BasicServices) {
            _adminServices = AdminServices;
            _basicServices = BasicServices;
        }

        // GET: Admin
        public ActionResult CreateOEM() {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOEM(CreateOEM CreateOEM) {
            var manufacturer = ConvertToEntityOEM(CreateOEM);
            _adminServices.AddOEM(manufacturer);
            return RedirectToAction("index", "Home", null);
        }

        [HttpGet]
        public ActionResult CreatePhone(int oemID = 0) {
            CreatePhoneModel phoneModel = new CreatePhoneModel();
            if (oemID != 0)
            {
                phoneModel.OEMID = oemID;
            }
            var items = ConvertToOEMS();
            var list = items.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.ID.ToString()
            });
            ViewData["OEMS"] = items;
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreatePhone(CreatePhoneModel PhoneModel) {
            var phone = ConvertToEntityPhone(PhoneModel);
            phone.Views = 0;
            _adminServices.AddPhone(phone);
            return RedirectToAction("GetOEMPhones", "Home", PhoneModel.OEMID); 
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreatePost() {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreatePost(PostModel model) {
            Post newPost = new Post() {
                Subject = model.Subject,
                Content = model.Content,
                CreateDate = DateTime.Now,
                User = _basicServices.FindUserByEmail(User.Identity.Name),
                Views = 0
            };
            if (_adminServices.AddPost(newPost)) {
                return RedirectToAction("Index", "Home", null);
            } 
            return View();
        }

        private List<ModelOEM> ConvertToOEMS()
        {
            var oems = _basicServices.GetOEMS();
            List<ModelOEM> oemList = new List<ModelOEM>();
            foreach (var item in oems)
            {
                ModelOEM mOEM = new ModelOEM
                {
                    ID = item.ID,
                    Name = item.Name
                };
                oemList.Add(mOEM);
            }
            return oemList;
        }

        private Manufacturer ConvertToEntityOEM(CreateOEM createOEM) {
            return new Manufacturer() { Country = createOEM.Country, Name = createOEM.Name };
        }

        private Phone ConvertToEntityPhone(CreatePhoneModel Model) {
            return new Phone {
                PhoneName = Model.PhoneName,
                Model = Model.Model,
                Resolution = Model.Resolution,
                OS = Model.OS,
                GPU = Model.GPU,
                CPU = Model.CPU,
                BatteryCapacity = Model.BatteryCapacity,
                MainCamera = Model.MainCamera,
                SecondaryCamera = Model.SecondaryCamera,
                OEMID = Model.OEMID,
                Manufacturer = _basicServices.GetManufacturer(Model.OEMID),
                ReleaseDate = Model.RealseDate,
                Price = Model.Price
               
            };
        }
    }
}