import { GoogleUserDto } from '../dto/GoogleUserDto';
import { GoogleApiService } from '../../api/GoogleApiService';
import { ApiService } from '../../api/ApiService';

export class TokenValidator {
    private tokenString: string

    constructor(tokenString: string) {
        this.tokenString = tokenString
    }

    async getState(): Promise<TokenState> {
        const isTokenValid = await GoogleApiService.isTokenValid(this.tokenString);

        if (!isTokenValid) {
            return {
                validity: TokenValidity.NotValid,
                user: undefined
            };
        }

        const googleUserInfo = await GoogleApiService.fetchUserInfo(this.tokenString);

        try {
            const user = await ApiService.getUserByEmail(googleUserInfo.email);

            return {
                validity: TokenValidity.ValidUserExists,
                user: googleUserInfo
            };
        } catch (error) {
            return {
                validity: TokenValidity.ValidUserDoesNotExist,
                user: googleUserInfo
            };
        }
    }

}

export type TokenState = {
    validity: TokenValidity,
    user?: GoogleUserDto
}

export enum TokenValidity {
    ValidUserExists,
    ValidUserDoesNotExist,
    NotValid
}