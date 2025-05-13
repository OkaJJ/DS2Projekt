namespace DS2_Projekt.Models;

// CREATE TABLE visit_procedure (
//     visit_id int,
//     procedure_id int,
//     quantity int,
//     PRIMARY KEY (visit_id, procedure_id)
// );

public class VisitProcedure {
    public int visit_id { get; set; }
    public int procedure_id { get; set; }
    public int quantity { get; set; }
}