//
// One CTA Station
//

namespace program.Models
{

  public class Stops
	{
	
		// data members with auto-generated getters and setters:
                public int StopID { get; set; }
		public string StopName { get; set; }
		public string direction { get; set; }
                public string AD { get; set; }
                public string lattitude { get; set; }
                public string longitude { get; set; }
                public string color { get; set; }
	
		// default constructor:
		public Stops()
		{ }
		
		// constructor:
		public Stops(int id, string name, string Direction, string A, string Lattitude, string Longitude, string Color )
		{
			StopID = id;
                        StopName = name;
                        direction = direction;
                        AD = A;
                        lattitude = lattitude;
                        longitude = longitude;
                        color = color;
		}
		
	}//class

}//namespace