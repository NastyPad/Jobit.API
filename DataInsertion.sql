--Users
INSERT INTO users (user_id, username, firstname,lastname, password, profile_photo_url, email)
VALUES (0, "vimleo", "Leonardo Manuel", "Grau Vargas", "1234", "none", "admin@gmail.com");

--Companies
INSERT INTO companies (company_id, company_name, password, profile_photo_url, company_email, description)
VALUES (0, "ADMIN S.A.C", "1234", "none", "admin@gmail.com", "sample");

--TechSkills
INSERT INTO tech_skills(
  tech_skill_id,
  tech_name,
  photo_url
)
VALUES(
  0,
  "Vue.js",
  "https://upload.wikimedia.org/wikipedia/commons/thumb/9/95/Vue.js_Logo_2.svg/1200px-Vue.js_Logo_2.svg.png"
);

INSERT INTO tech_skills(
  tech_skill_id,
  tech_name,
  photo_url
)
VALUES(
  1,
  "Flutter",
  "https://seeklogo.com/images/F/flutter-logo-5086DD11C5-seeklogo.com.png"
);

INSERT INTO tech_skills(
  tech_skill_id,
  tech_name,
  photo_url
)
VALUES(
  1,
  "Flutter",
  "https://seeklogo.com/images/F/flutter-logo-5086DD11C5-seeklogo.com.png"
);


