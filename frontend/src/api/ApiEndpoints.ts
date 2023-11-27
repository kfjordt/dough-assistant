const port = 44369

export const ApiEndpoints = {
    POST_SessionCookie: `https://localhost:${port}/api/Authentication/SessionCookie`,
    POST_RememberMeCookie: `https://localhost:${port}/api/Authentication/RememberMeCookie`,
    POST_RememberMeCookieValidation: `https://localhost:${port}/api/Authentication/RememberMeCookieValidation`,
    GET_Expense: `https://localhost:${port}/api/Expense`,
    POST_Expense: `https://localhost:${port}/api/Expense`,
    GET_Currency: `https://localhost:${port}/api/Currency`,
}