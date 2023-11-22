import { ApiEndpoints } from './ApiEndpoints';
import { UserDto } from '../models/dto/UserDto'
import { ExpenseDto } from '../models/dto/ExpenseDto';
import { Currency } from '../models/data/Currency';

export class ApiService {
    static requestNewSession = async (googleJwt: string): Promise<UserDto> => {
        const urlParams = new URLSearchParams()
        urlParams.append('googleJwt', googleJwt)

        const requestNewSessionUrl = ApiEndpoints.SESSIONS + "?" + urlParams.toString()
        const response = await fetch(requestNewSessionUrl, {
            credentials: 'include'
        })

        if (response.ok) {
            return await response.json()
        } else {
            throw new Error(response.statusText)
        }
    }

    static postNewExpense = async (expense: ExpenseDto) => {
        const response = await fetch(ApiEndpoints.EXPENSES, {
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
        const response = await fetch(ApiEndpoints.EXPENSES, {
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
        const response = await fetch(ApiEndpoints.CURRENCY)

        if (response.ok) {
            const data = await response.json()
            return data
        } else {
            throw new Error(response.statusText)
        }
    }
}
