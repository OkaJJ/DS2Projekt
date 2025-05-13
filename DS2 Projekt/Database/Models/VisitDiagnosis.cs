namespace DS2_Projekt.Models;

// CREATE TABLE visit_diagnosis (
//     visit_id int,
//     diagnosis_id int,
//     PRIMARY KEY (visit_id, diagnosis_id)
// );

public class VisitDiagnosis {
    public int visit_id { get; set; }
    public int diagnosis_id { get; set; }
}