<script setup lang="ts">
import { googleSdkLoaded } from "vue3-google-login";
import { ref } from 'vue';
import { clientSecrets } from '../../ClientSecrets';
import { ApiService } from '../../api/ApiService';
import { DateTime } from '../../models/common/DateTime';
import { setCookie } from 'typescript-cookie'
import { useUserStore } from '../../stores/user';

const stayLoggedIn = ref(false);
const userStore = useUserStore()

const handleGoogleToken = (response: any) => {
    const token = response.credential as string

    ApiService.requestNewSession(token)
        .then(userId => userStore.setLoggedInUserId(userId))
        .catch(error => console.error(error))
}
</script>

<template>
    <div class="auth">
        <h1 class="auth-header">Dough Assistant</h1>
        <h2 class="auth-subheader">Blazingly brisk budgeting</h2>
        <GoogleLogin class="google-sign-in" :callback="handleGoogleToken"/>
    </div>
</template>

<style scoped>
.auth {
    padding: 30px;
    color: rgb(210, 210, 210);
    background-color: rgb(50, 50, 50);
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

.google-sign-in {
    margin-top: 30px;
}</style>
