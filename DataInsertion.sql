--Users
INSERT INTO users (user_id, username, firstname,lastname, password, profile_photo_url, email)
VALUES (0, "admin", "admin", "admin", "1234", "none", "admin@gmail.com");

--Companies
INSERT INTO companies (company_id, company_name, password, profile_photo_url, company_email, description)
VALUES (0, "ADMIN S.A.C", "1234", "none", "admin@gmail.com", "sample");

--TechSkills
INSERT INTO tech_skills(
  tech_skill_id,
  tech_name,
  photo_url
)
VALUES 