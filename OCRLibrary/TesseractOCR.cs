﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace OCRLibrary
{
    public class TesseractOCR : OCREngine
    {
        public string srcLangCode;//OCR识别语言 jpn=日语 eng=英语
        private TesseractEngine TessOCR;

        public override string OCRProcess(Bitmap img)
        {
            try {
                var page = TessOCR.Process(img);
                string res = page.GetText();
                page.Dispose();
                return res;
            }
            catch (Exception ex) {
                errorInfo = ex.Message;
                return null;
            }
        }

        public override bool OCR_Init(string param1 = "", string param2 = "")
        {
            try
            {
                TessOCR = new TesseractEngine(Environment.CurrentDirectory + "\\tessdata", srcLangCode, EngineMode.Default);
                return true;
            }
            catch(Exception ex)
            {
                errorInfo = ex.Message;
                return false;
            }
        }
        public override void SetOCRSourceLang(string lang)
        {
            srcLangCode = lang;
        }
    }
}
