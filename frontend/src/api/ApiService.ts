import { ApiEndpoints } from './ApiEndpoints';
import { UserDto } from "../models/dto/UserDto"

export class ApiService {
    static postUser = async (email: string, name: string) => {
        const requestPayload = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
                email: email,
                name: name
            })
        }

        const response = await fetch(ApiEndpoints.POST_USER, requestPayload)
        
        if (response.ok) {
            return response.status
        } else {
            throw new Error(`Failed to post user. API call returned code ${response.status}`)
        }
    }

    static getUserByEmail = async (email: string): Promise<UserDto> => {
        const response = await fetch(`${ApiEndpoints.GET_USER}/${email}`);

        if (response.ok) {
            const jsonResponse = await response.json();

            return {
                name: jsonResponse.name,
                email: jsonResponse.email
            };
        } else {
            throw new Error(`Failed to fetch user by email: ${response.statusText}`);
        }
    };

}