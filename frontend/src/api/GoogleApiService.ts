import { ApiEndpoints } from './ApiEndpoints';
import { ApiService } from './ApiService';
import { OAuth2Client } from "google-auth-library"
import { GoogleUserDto } from '../models/dto/GoogleUserDto';

export class GoogleApiService {
    static fetchUserInfo = async (accessToken: string): Promise<GoogleUserDto> => {
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

    static isTokenValid = async (accessToken: string): Promise<boolean> => {
        // https://developers.google.com/identity/sign-in/web/backend-auth
        const params = new URLSearchParams({
            access_token: accessToken
        });

        const response = await fetch(`${ApiEndpoints.GOOGLE_BEARER_TOKEN_VERIFICATION}?${params}`);

        if (response.ok) {
            return true;
        } else {
            return false;
        }
    }

}
