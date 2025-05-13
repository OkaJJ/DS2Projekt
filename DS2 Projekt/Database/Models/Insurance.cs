namespace DS2_Projekt.Models;

// CREATE TABLE insurance (
//     insurance_id int PRIMARY KEY,
//     name varchar2(255),
//     code varchar2(20)
// );

public class Insurance {
    public int insurance_id { get; set; }
    public string name { get; set; }
    public string code { get; set; }
}