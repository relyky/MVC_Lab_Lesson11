using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Text.RegularExpressions;
using MVC_Lab_Lesson11.Models;

namespace MVC_Lab_Lesson11.Controllers
{
    public class Lesson11Controller : Controller
    {
        // GET: Lesson11
        public ActionResult Default()
        {
            MyModel data = new MyModel();
            data.name = "AllowHtml";
            data.value = @"<em><strong>some stuff</strong></em>"
                        + @"<script>alert('boom');</script>";
            return View(data);
        }

        [HttpPost]
        [ValidateInput(false)] // 解除 Action 的指令檢查
        public ActionResult Default(MyModel data)
        {
            data.value = MyHtmlHelper.SafeHtml(data.value); // 過濾“不合法”的內容
            return View(data);
        }
    }

    class MyHtmlHelper
    {
        /// <summary>
        /// 過濾“不合法”的內容
        /// </summary>
        public static string SafeHtml(string str)
        {
            var filterString = str == null ? "" : str.Trim(); // formulate
            if (string.IsNullOrWhiteSpace(filterString)) return null; // validate

            //## 只留下幾個顯示設定的標籤： <br>, <p>, <style>, <span>, <em>, <strong>
            var regex = new Regex(@"<(?!br|\/?p|style|\/?span|\/?em|\/?strong)[^>]*>"); // "illegal tag" pattern
            filterString = regex.Replace(filterString, ""); // 將 "illegal tag" 全移除；即：只留下合法的標籤

            return filterString;
            //return new HtmlString(filterString);
        }
    }
}