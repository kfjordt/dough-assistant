import { ApiEndpoints } from './ApiEndpoints';
import { parseGoogleResponseToUserInfo } from '../models/GoogleUserInfo';
import { ApiService } from './ApiService';

export class GoogleApiService {
    static fetchUserInfo = async (accessToken: string) => {
        const requestPayload = {
            headers: {
                'Authorization': `Bearer ${accessToken}`
            }
        }

        const response = await fetch(ApiEndpoints.GOOGLE_USER_INFO, requestPayload);
        if (response.ok) {
            const data = await response.json();
            return parseGoogleResponseToUserInfo(data);
        } else {
            throw new Error('Failed to fetch user info');
        }
    }
}
