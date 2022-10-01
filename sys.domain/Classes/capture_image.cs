using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sys.domain.Classes
{
	public class imaging
	{
		public string ip { get; set; }
		public int time_out { get; set; }
		private System.Drawing.Image _image;
		private System.Drawing.Image _minimage;
		public System.Drawing.Image minimage { get { return _minimage; } set { _minimage = value; } }
		public System.Drawing.Image image { get { return _image; } set { _image = value; } }

		public void capture_image_from_device()
		{
			string url = "http://" + ip + "/cgi-bin/viewer/video.jpg?resolution=1600x1200";
			System.Net.HttpWebRequest HWR;
			HWR = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
			HWR.AllowWriteStreamBuffering = true;
			HWR.Timeout = time_out;
			System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)HWR.GetResponse();
			System.IO.Stream stream = response.GetResponseStream();
			System.IO.MemoryStream mstream = new System.IO.MemoryStream();

			_image = System.Drawing.Image.FromStream(stream);
		}

		public void get_image_from_file(string path)
		{
			_image = System.Drawing.Image.FromFile(path);
		}

		public byte[] convert_min_image_to_byte()
		{
			byte[] res;

			res = (byte[])new System.Drawing.ImageConverter().ConvertTo(_minimage, typeof(byte[]));

			return res;
		}

		public byte[] convert_image_to_byte()
		{
			byte[] res;

			res = (byte[])new System.Drawing.ImageConverter().ConvertTo(_image, typeof(byte[]));

			return res;
		}

		public void reduce_image_size(double scaleFactor)
		{
			System.IO.MemoryStream origImageStream = new System.IO.MemoryStream();
			_image.Save(origImageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

			System.IO.MemoryStream minImageStream = new System.IO.MemoryStream();

			using (var origimage = System.Drawing.Image.FromStream(origImageStream))
			{
				var newWidth = (int)(origimage.Width * scaleFactor);
				var newHeight = (int)(origimage.Height * scaleFactor);
				_minimage = new System.Drawing.Bitmap(newWidth, newHeight);
				var thumbGraph = System.Drawing.Graphics.FromImage(_minimage);
				thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
				thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
				var imageRectangle = new System.Drawing.Rectangle(0, 0, newWidth, newHeight);
				thumbGraph.DrawImage(origimage, imageRectangle);
				_minimage.Save(minImageStream, origimage.RawFormat);
			}

			_minimage = System.Drawing.Image.FromStream(minImageStream);

		
		}
	}
}
