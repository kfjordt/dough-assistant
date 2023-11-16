import { ApiEndpoints } from './ApiEndpoints'
import { UserDto } from '../models/dto/UserDto'

export class ApiService {
    static requestNewSession = async (googleAuthToken: string, user: UserDto) => {
        const urlParams = new URLSearchParams()
        urlParams.append('googleAuthToken', googleAuthToken)

        const requestNewSessionUrl = ApiEndpoints.REQUEST_SESSION + "?" + urlParams.toString()
        const requestPayload = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(user),
        }
        
        fetch(requestNewSessionUrl, requestPayload)


        // if (response.ok) {
        //     return response.status
        // } else {
        //     throw new Error(
        //         `Failed to post user. API call returned code ${response.status}`
        //     )
        // }
    }
}
