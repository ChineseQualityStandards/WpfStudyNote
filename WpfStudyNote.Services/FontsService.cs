using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Services
{
    public class FontsService : IFontsService
    {
        public FontsProperties GetFontsProperties()
        {
            var fonts = new FontsProperties();
            foreach (var item in new InstalledFontCollection().Families)
            {
                fonts.FontFamily.Add(item.Name);
            }
            for (var i = 10; i < 80; i++)
            {
                fonts.FontSize.Add(i);
                i++;
            }
            return fonts;
        }
    }
}
