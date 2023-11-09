import { UserInfo } from '../models/GoogleUserInfo';
import { ApiEndpoints } from './ApiEndpoints';

export class ApiService {
    static postUser = async (userInfo: UserInfo, time: Date) => {
        let requestBody = { ...userInfo } as any
        requestBody.registrationDate = time

        console.log(requestBody)
        const requestPayload = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(requestBody)
        }

        const response = await fetch(ApiEndpoints.POST_USER, requestPayload)
        if (response.ok) {
            return response.status
        } else {
            throw new Error(`Failed to post user. API call returned code ${response.status}`)
        }
    }
}