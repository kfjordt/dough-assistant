<script setup lang="ts">
import { googleSdkLoaded } from "vue3-google-login";
import { ref } from 'vue';
import { clientSecrets } from '../../ClientSecrets';
import { ApiService } from '../../api/ApiService';
import { DateTime } from '../../models/common/DateTime';
import { setCookie } from 'typescript-cookie'
import { TokenValidator, TokenValidity, TokenState } from '../../models/common/TokenValidator';
import { useStore } from '../../store/store';
import { GoogleApiService } from '../../api/GoogleApiService';

const stayLoggedIn = ref(false);

const store = useStore()

const handleAccessToken = (bearerToken: string) => {
    console.log(bearerToken);
    const userInfo = GoogleApiService.fetchUserInfo(bearerToken)
        .then(user => ApiService.requestNewSession(bearerToken, user)
            .then(res => {  })
        )
        .catch(_ => console.log("Failed to fetch user info from Google API"))
}

const promptUserForGoogleLogin = async () => {
    googleSdkLoaded(google => {
        google.accounts.oauth2.initTokenClient({
            client_id: clientSecrets.googleClientId,
            scope: "email profile",

            callback: (response) => {
                const accessToken = response.access_token;
                handleAccessToken(accessToken)
            }
        }).requestAccessToken()
    });
}
</script>

<template>
    <div class="auth">
        <h1 class="auth-header">Dough Assistant</h1>
        <h2 class="auth-subheader">Blazingly brisk budgeting</h2>
        <button @click="promptUserForGoogleLogin" class="auth-button">Sign in with Google</button>
        <div>
            <input id="stay-logged-in" type="checkbox" v-model="stayLoggedIn">
            <label for="stay-logged-in">Keep me logged in for 30 days</label>
        </div>
    </div>
</template>

<style scoped>
.auth {
    margin: 20px;
    padding: 10px;
    border: 1px solid rgb(125, 125, 125);
    border-radius: 10px;
    user-select: none;
    display: flex;
    flex-direction: column;
    align-items: center;
}

.auth-header,
.auth-subheader {
    margin: 0;
    padding: 5px
}

.auth-subheader {
    font-weight: normal;
}

.auth-button {
    margin-top: 30px;
    cursor: pointer;
}
</style>