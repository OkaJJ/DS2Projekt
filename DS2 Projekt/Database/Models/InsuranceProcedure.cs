namespace DS2_Projekt.Models;

// CREATE TABLE insurance_procedure (
//     insurance_id int,
//     procedure_id int,
//     covered int,
//     PRIMARY KEY (insurance_id, procedure_id)
// );

public class InsuranceProcedure {
    public int insurance_id { get; set; }
    public int procedure_id { get; set; }
    public int covered { get; set; }
}