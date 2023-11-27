import { ApiEndpoints } from './ApiEndpoints';
import { UserDto } from '../models/dto/UserDto'
import { ExpenseDto } from '../models/dto/ExpenseDto';
import { Currency } from '../models/data/Currency';

export class ApiService {
    // It should actually both be able to request session cookies from user id + remembermetoken 

    static requestSessionCookie = async (googleJwt: string): Promise<string> => {
        const urlParams = new URLSearchParams()
        urlParams.append('googleJwt', googleJwt)

        const requestNewSessionUrl = ApiEndpoints.POST_SessionCookie + "?" + urlParams.toString()
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

    static requestRememberMeCookie = async (userId: string) => {
        const urlParams = new URLSearchParams()
        urlParams.append('userId', userId)

        const requestNewSessionUrl = ApiEndpoints.POST_RememberMeCookie + "?" + urlParams.toString()
        const response = await fetch(requestNewSessionUrl, {
            credentials: 'include',
            method: "POST"
        })


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
