using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using Microsoft.AspNetCore.Mvc.RazorPages;  
using System.Data;
  
namespace program.Pages  
{  
    public class StopsInfoModel : PageModel  
    {  
				public List<Models.Stops> StopsList { get; set; }
				public string Input { get; set; }
				public Exception EX { get; set; }
        public bool duplicate(string name, string color){
                foreach (Models.Stops data in StopsList){
                        if(string.Equals(name, data.StopName) == true){
                                data.color += (";" + color);
                                return true;
                        }
                }
                return false;
        }
  
        public void OnGet(string input)  
        {  
				  StopsList = new List<Models.Stops>();
					
					// make input available to web page:
					Input = input;
					
					// clear exception:
					EX = null;
					
					try
					{
						//
						// Do we have an input argument?  If not, there's nothing to do:
						//
						if (input == null)
						{
							//
							// there's no page argument, perhaps user surfed to the page directly?  
							// In this case, nothing to do.
							//
						}
						else  
						{
							// 
							// Lookup movie(s) based on input, which could be id or a partial name:
							// 
							string sql;

						  // lookup station(s) by partial name match:
							input = input.Replace("'", "''");

							sql = string.Format(@"
	SELECT Stops.StopID, Stops.Name, Stops.Direction, Stops.ADA, Stops.Latitude, Stops.Longitude, Lines.Color FROM Stops 
        RIGHT JOIN StopDetails ON Stops.StopID = StopDetails.StopID
        RIGHT JOIN Lines ON StopDetails.LineID = Lines.LineID
        WHERE StationID = '{0}' 
        GROUP BY Stops.StationID, Stops.StopID, Stops.Name, Stops.Direction, Stops.ADA, Stops.Latitude, Stops.Longitude, Lines.Color
        Order BY Lines.Color ASC;
	", input);

							DataSet ds = DataAccessTier.DB.ExecuteNonScalarQuery(sql);

							foreach (DataRow row in ds.Tables[0].Rows)
							{
								string TName = Convert.ToString(row["Name"]);
                                                                string color = Convert.ToString(row["Color"]);
                                                                Models.Stops s = new Models.Stops();
                                                                if(duplicate(TName,color) == false){
                                                                        s.StopID = Convert.ToInt32(row["StopID"]);
                                                                        s.StopName = Convert.ToString(row["Name"]);
                                                                        s.direction = Convert.ToString(row["Direction"]);
                                                                        //s.AD = Convert.ToString(row["Name"]);
                                                                        if(Convert.ToInt32(row["ADA"]) == 1){
                                                                                s.AD = "yes";

                                                                        }
                                                                        else{
                                                                                s.AD = "no";
                                                                        }
                                                                        s.lattitude = Convert.ToString(row["Latitude"]);
                                                                        s.longitude = Convert.ToString(row["Longitude"]);
                                                                        s.color = Convert.ToString(row["Color"]);
                                                                        StopsList.Add(s);
                                                                
                                                                }

                                                                
                                                                
                                                                

								
                                                                
							}
						}//else
					}
					catch(Exception ex)
					{
					  EX = ex;
					}
					finally
					{
					  // nothing at the moment
				  }
				}
			
    }//class  
}//namespace