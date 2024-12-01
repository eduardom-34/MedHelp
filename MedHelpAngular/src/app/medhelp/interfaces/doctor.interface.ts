export interface Doctor {
  id:             number;
  firstName:      string;
  lastName:       string;
  userName:       string;
  email:          string;
  birthDate:      Date;
  signUpDate:     Date;
  specialtyNames: SpecialtyName[];
}

export enum SpecialtyName {
  GeneralPractitionerGP = "General Practitioner (GP):",
  TestValidationItHsouldWorkNow = "Test Validation, it hsould work now",
  TestingRefactoring = "Testing refactoring",
}
