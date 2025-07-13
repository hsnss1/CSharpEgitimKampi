using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampiEFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
           
            lblAvgCapacity.Text = db.Location.Average(x => x.Capacity).ToString();  
            lblCumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAvgLocationPrice.Text = db.Location.Average(x => x.Price).ToString();
            lblLocationCount.Text = db.Location.Count().ToString();
            lblLastCountryName.Text = db.Location.OrderByDescending(x => x.LocationId).Select(y => y.Country).FirstOrDefault();
            lblTurkiyeCapacityAvg.Text = db.Location.Where(x => x.Country == "Türkiye").Average(y => y.Capacity).ToString();
            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya" + " ").Select(y => y.Capacity).FirstOrDefault().ToString();
            

            var moscowGuideId = db.Location.Where(x => x.City == "Moskova").Select(x => x.GuideId).FirstOrDefault();
            var guide = db.Guide.FirstOrDefault(x => x.GuideId == moscowGuideId);
            lblMoscowGuideName.Text = guide != null ? guide.GuideName + " " + guide.GuideSurname : "No guide found";

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x=>x.Capacity == maxCapacity).Select(y=> y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdByNameHasanCaglar = db.Guide.Where(x => x.GuideName == "Hasan" && x.GuideSurname == "Çağlar").Select(x => x.GuideId).FirstOrDefault();
            lblHasanCaglarLocationCount.Text = db.Location.Count(x => x.GuideId == guideIdByNameHasanCaglar).ToString();
        }
    }
}
