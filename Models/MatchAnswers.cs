namespace VehicleInventoryProj.Models
{
    public class MatchAnswers
    {
        public string VehicleType { get; set; }  // e.g., SUV, Minivan
        public string FuelType { get; set; }     // e.g., Gas, EV
        public int? MinBudget { get; set; }      // Min budget
        public int? MaxBudget { get; set; }      // Max budget
        public int? Passengers { get; set; }     // Number of passengers
    }

}
