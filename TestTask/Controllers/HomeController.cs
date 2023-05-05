using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using TestTask.Models;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace TestTask.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult SaveHuman() => View();

        [HttpPost]
        public IActionResult SaveHuman(HumanModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            SaveDataToJson(model);

            return RedirectToAction("Saved");
        }

        private void SaveDataToJson(HumanModel model)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(model, options);
            string directory = Directory.GetCurrentDirectory() + "\\Data\\Humans\\";
            string fileExtension = ".json";
            string fileName = "human";

            int i = 1;
            while (System.IO.File.Exists(directory + fileName + i + fileExtension))
            {
                i++;
            }
            string path = directory + fileName + i + fileExtension;

            StreamWriter sw = new StreamWriter(path);
            sw.Write(json);
            sw.Close();
        }
        public IActionResult Saved() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}