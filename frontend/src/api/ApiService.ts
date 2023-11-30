import { ApiEndpoints } from './ApiEndpoints';
import { UserDto } from '../models/dto/UserDto'
import { ExpenseDto } from '../models/dto/ExpenseDto';
import { Currency } from '../models/data/Currency';

export class ApiService {
    static getLoggedInUserIdFromRememberMeCookie = async () => {
        const response = await fetch(ApiEndpoints.GetLoggedInUserIdFromRememberMeCookie, {
            credentials: 'include',
        })

        if (response.ok) {
            const responseBody = await response.text()
            return responseBody
        } else {
            throw new Error(response.statusText)
        }
    }
    
    static getLoggedInUserIdFromSessionCookie = async () => {
        const response = await fetch(ApiEndpoints.GetLoggedInUserIdFromSessionCookie, {
            credentials: 'include',
        })

        if (response.ok) {
            const responseBody = await response.text()
            return responseBody
        } else {
            throw new Error(response.statusText)
        }
    }

    static isSessionCookieValid = async () => {
        const response = await fetch(ApiEndpoints.IsSessionCookieValid, {
            credentials: 'include',
        })

        if (response.ok) {
            const responseBody = await response.text()
            return responseBody
        } else {
            throw new Error(response.statusText)
        }
    }

    static requestSessionCookie = async (googleJwt: string): Promise<string> => {
        const urlParams = new URLSearchParams()
        urlParams.append('googleJwt', googleJwt)

        const requestNewSessionUrl = ApiEndpoints.GetSessionCookie + "?" + urlParams.toString()
        const response = await fetch(requestNewSessionUrl, {
            credentials: 'include',
            method: "POST"
        })

        if (response.ok) {
            const responseBody = await response.text()
            return responseBody
        } else {
            throw new Error(response.statusText)
        }
    }

    static isRememberMeCookieValid = async () => {
        const response = await fetch(ApiEndpoints.IsRememberMeCookieValid, {
            credentials: 'include',
        })

        if (response.ok) {
            const responseBody = await response.text()
            return responseBody
        } else {
            throw new Error(response.statusText)
        }
    }

    static requestRememberMeCookie = async (userId: string) => {
        const urlParams = new URLSearchParams()
        urlParams.append('userId', userId)

        const requestNewSessionUrl = ApiEndpoints.GetRememberMeCookie + "?" + urlParams.toString()
        const response = await fetch(requestNewSessionUrl, {
            credentials: 'include',
            method: "POST"
        })

        if (response.ok) {
            const responseBody = await response.text()
            return responseBody
        } else {
            throw new Error(response.statusText)
        }
    }

    static postNewExpense = async (expense: ExpenseDto) => {
        const response = await fetch(ApiEndpoints.POST_Expense, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            credentials: 'include',
            body: JSON.stringify(expense),
        })

        return response
    }

    static getExpenses = async () => {
        const response = await fetch(ApiEndpoints.GET_Expense, {
            credentials: 'include'
        })

        if (response.ok) {
            const data = await response.json()
            return data
        } else {
            throw new Error(response.statusText)
        }
    }

    static getCurrencies = async (): Promise<Currency[]> => {
        const response = await fetch(ApiEndpoints.GET_Currency)

        if (response.ok) {
            const data = await response.json()
            return data
        } else {
            throw new Error(response.statusText)
        }
    }
}
