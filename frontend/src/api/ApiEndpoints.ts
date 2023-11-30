const port = 44369

export const ApiEndpoints = {
    GetLoggedInUserIdFromRememberMeCookie: `https://localhost:${port}/api/Authentication/GetLoggedInUserIdFromRememberMeCookie`,
    GetLoggedInUserIdFromSessionCookie: `https://localhost:${port}/api/Authentication/GetLoggedInUserIdFromSessionCookie`,
    GetSessionCookie: `https://localhost:${port}/api/Authentication/GetSessionCookie`,
    IsSessionCookieValid: `https://localhost:${port}/api/Authentication/IsSessionCookieValid`,
    GetRememberMeCookie: `https://localhost:${port}/api/Authentication/GetRememberMeCookie`,
    IsRememberMeCookieValid: `https://localhost:${port}/api/Authentication/IsRememberMeCookieValid`,
    GET_Expense: `https://localhost:${port}/api/Expense`,
    POST_Expense: `https://localhost:${port}/api/Expense`,
    GET_Currency: `https://localhost:${port}/api/Currency`,
}