<template>
    <div>
        <button @click="promptUserForGoogleLogin">Login Using Google</button>
    </div>
</template>


<script setup lang="ts">
import { googleSdkLoaded } from "vue3-google-login";
import { defineComponent } from "vue";
import { clientSecrets } from '../clientSecrets';
import { GoogleApiService } from '../api/GoogleApiService';
import { ApiService } from '../api/ApiService';

const promptUserForGoogleLogin = () => {
    googleSdkLoaded(google => {
        google.accounts.oauth2.initTokenClient({
            client_id: clientSecrets.googleClientId,
            scope: "email profile",
            callback: (response) => {
                GoogleApiService.fetchUserInfo(response.access_token)
                    .then(userInfo => {
                        const time = new Date(Date.now())
                        ApiService.postUser(userInfo, time)
                    })
                    .catch(error => {
                        console.error('Failed to fetch user info:', error);
                    });
            }
        }).requestAccessToken()
    });
}
</script>