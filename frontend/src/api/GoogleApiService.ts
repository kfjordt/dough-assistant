import { ApiEndpoints } from './ApiEndpoints';
import { ApiService } from './ApiService';
import { OAuth2Client } from "google-auth-library"
import { UserDto } from '../models/dto/UserDto';

export class GoogleApiService {
    static fetchUserInfo = async (accessToken: string): Promise<UserDto> => {
        const requestPayload = {
            headers: {
                'Authorization': `Bearer ${accessToken}`
            }
        }

        const response = await fetch(ApiEndpoints.GOOGLE_USER_INFO, requestPayload);
        if (response.ok) {
            const data = await response.json();
            return {
                email: data.email,
                name: data.name,
            }
        } else {
            throw new Error('Failed to fetch user info');
        }
    }
}
