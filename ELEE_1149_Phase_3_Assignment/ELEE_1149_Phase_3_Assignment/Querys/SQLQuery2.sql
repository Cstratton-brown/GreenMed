SELECT Login.Role,
	   Login.LoginID,
	   Login.LoginPassword
FROM Login
WHERE CONVERT(VARCHAR,Login.LoginID) = '@txtID' and CONVERT(VARCHAR,Login.LoginPassword) = '@txtPassword'