<script setup lang="ts">
import { ApiService } from '../../api/ApiService';
import { useUserStore } from '../../stores/user';
import { useRouter } from 'vue-router'
import { ref } from 'vue';

const userStore = useUserStore()
const router = useRouter()

const rememberMe = ref(false)

const handleGoogleToken = (response: any) => {
    const token = response.credential as string

    ApiService.requestSessionCookie(token)
        .then(userId => {
            if (rememberMe.value) {
                ApiService.requestRememberMeCookie(userId)
            }

            userStore.setLoggedInUserId(userId)
            router.push("main")
        })
        .catch(error => console.error(error))
}

const handleSubheaderClick = () => {
    router.push("brainstorming")
}
</script>

<template>
    <div class="login-container">
        <div class="login">
            <h1 class="auth-header">Dough Assistant</h1>
            <h2 @click="handleSubheaderClick()" class="auth-subheader">Blazingly brisk budgeting</h2>
            <GoogleLogin class="google-sign-in" :callback="handleGoogleToken" />
            <div class="remember-me-container">
                <input v-model="rememberMe" id="remember-me-checkbox" type="checkbox" />
                <label for="remember-me-checkbox">Remember me</label>
            </div>
        </div>
    </div>
</template>

<style scoped>
.login-container {
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
}

.login {
    border-radius: 10px;
    padding: 28px;
    user-select: none;
    display: flex;
    flex-direction: column;
    align-items: center;
    color: rgb(210, 210, 210);
    background-color: rgb(50, 50, 50);
}

.auth-header,
.auth-subheader {
    margin: 0;
    padding: 4px
}

.auth-subheader {
    font-weight: normal;
}

.google-sign-in {
    margin-top: 30px;
}

.remember-me-container {
    margin-top: 5px;
    display: flex;
    align-items: center;
}
</style>
