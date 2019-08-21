//
// One CTA Station
//

namespace program.Models
{

  public class Station
	{
	
		// data members with auto-generated getters and setters:
	  public int StationID { get; set; }
		public string StationName { get; set; }
		public int AvgDailyRidership { get; set; }
                public int NoOfStops { get; set; }
                public string HandicapAccessible { get; set; }
	
		// default constructor:
		public Station()
		{ }
		
		// constructor:
		public Station(int id, string name, int avgDailyRidership, int stops, string handicap )
		{
			StationID = id;
                        //,string accessible
			StationName = name;
			AvgDailyRidership = avgDailyRidership;
                        NoOfStops = stops;
                        HandicapAccessible = handicap;
		}
		
	}//class

}//namespace