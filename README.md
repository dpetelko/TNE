# TNE

To check LeadDivision controller POST operation in Postman app, create POST request http://localhost:8050/api/v1/LeadDivisions with body:

{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "LD#1",
    "addressId": "00000000-0000-0000-0000-000000000000",
    "postCode": 123456,
    "country": "Russia",
    "region": "Krasnodarskiy",
    "city": "Krasnodar",
    "street": "Lenina",
    "building": "3a"
    
}

A repeated POST request will throw an error validating the uniqueness of the NAME field.
Validation of the uniqueness of the NAME field is implemented as a custom validator in the UniqueField.cs class