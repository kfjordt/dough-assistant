import { ApiEndpoints } from './ApiEndpoints';
import { UserDto } from '../models/dto/UserDto'
import { ExpenseDto } from '../models/dto/ExpenseDto';

export class ApiService {
    static requestNewSession = async (googleAccessToken: string): Promise<UserDto> => {
        const urlParams = new URLSearchParams()
        urlParams.append('googleAccessToken', googleAccessToken)

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
            credentials: 'include', // Set credentials here
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
}
