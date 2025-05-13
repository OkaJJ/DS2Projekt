namespace DS2_Projekt.Models;

// CREATE TABLE patient (
//     patient_id int PRIMARY KEY,
//     first_name varchar2(100),
//     last_name varchar2(100),
//     birth_date date,
//     birth_number varchar2(20),
//     insurance_id int
// );

public class Patient {
    public int patient_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public DateTime birth_date { get; set; }
    public string birth_number { get; set; }
    public int insurance_id { get; set; }
}