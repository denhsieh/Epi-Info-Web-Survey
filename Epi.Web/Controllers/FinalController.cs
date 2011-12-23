﻿using System.Web.Mvc;
using Epi.Web.MVC.Facade;
using Epi.Web.MVC.Models;
namespace Epi.Web.MVC.Controllers
{
    public class FinalController : Controller
    {
        

        //declare SurveyTransactionObject object
        private ISurveyFacade _isurveyFacade;
        /// <summary>
        /// Injectinting SurveyTransactionObject through Constructor
        /// </summary>
        /// <param name="iSurveyInfoRepository"></param>
        public FinalController(ISurveyFacade isurveyFacade)
        {

            _isurveyFacade = isurveyFacade;
        }
        public ActionResult Index(string surveyId,string final)
        {

            //if (!string.IsNullOrEmpty(final))
            //{
            SurveyInfoModel surveyInfoModel = _isurveyFacade.GetSurveyInfoModel(surveyId);
                return View(Epi.Web.MVC.Constants.Constant.SUBMIT_PAGE, surveyInfoModel);
            //}
            //return null;
            
        }

        

    }
}