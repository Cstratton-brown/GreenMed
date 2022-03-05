SELECT Login.LoginID,
	   Login.LoginPassword,
	   Login.Role
FROM Login
WHERE CONVERT(VARCHAR,Login.Role) = 'Doctor'