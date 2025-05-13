namespace DS2_Projekt.Models;

// CREATE TABLE visit (
//     visit_id int PRIMARY KEY,
//     patient_id int,
//     doctor_id int,
//     visit_date INT,
//     reason VARCHAR2(1000),
//     total_cost INT
// );

public class Visit {
    public int visit_id { get; set; }
    public int patient_id { get; set; }
    public int doctor_id { get; set; }
    public DateTime visit_date { get; set; }
    public string reason { get; set; }
    public int total_cost { get; set; }
}