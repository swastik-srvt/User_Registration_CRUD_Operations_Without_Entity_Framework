using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using User_Registration_CRUD_Operations_Without_Entity_Framework.Models;
using User_Registration_CRUD_Operations_Without_Entity_Framework.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User_Registration_CRUD_Operations_Without_Entity_Framework.Controllers
{
    public class UserController : Controller
    {
        /*it is a very major mistake I am not expecting you do this. this should be inside constructor, Also use meaningful names for variables and use var rather than tight coupling */
//         val dal = new DataAccessLayer();

             private readonly IUserDataAccessLayer _dataLayerFunction;
            
            public UserController(IUserDataAccessLayer dataLayerFunction)
        {
            _dataLayerFunction = dataLayerFunction;
        }
            
        // GET: UserController1
        public ActionResult Index()
        {
            ModelState.Clear();
            //first assign the value returned by GetDataList to some variable then return that variable, we might need to process data according to UI requirements
            var DataList =  View(_dataLayerFunction.GetDataList());
            return DataList;
        }

        // GET: UserController1/Details/5
        public ActionResult Details(int id)
        {
            var  userRegistration = View(_dataLayerFunction.GetDataList().Find(userRegistration = userRegistration)); 
            return userRegistration;
        }

        // GET: UserController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserRegistrationModel userRegistration)
        {
            //you have use logger, yu should log the error message also for exception
            try
            {
                //first check here if model state is valid
                if(UserRegistrationModel.IsValid)
                {
                       if(_dataLayerFunction.InsertData(userRegistration))
                     {
                       ViewBag.Message = "Data Saved";
                     }
                return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController1/Delete/5
        public ActionResult Delete(int id)
        {
            var deletedUser  = View(_dataLayerFunction.GetDataList().Find(userRegistration => userRegistration.Id  = id))
            return deletedUser;
        }

        // POST: UserController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserRegistrationModel userRegistration)
        {
            try
            {
              if(UserRegistrationModel.IsValid)
              {
                  if(_dataLayerFunction.DeleteData(userRegistration))
                    {
                        ViewBag.Message("Data Deleted")
                     }
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
