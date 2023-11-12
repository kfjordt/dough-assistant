<script setup lang="ts">
import MainView from './components/mainApp/MainView.vue';
import store from './store/store';
import Authentication from './components/other/Authentication.vue';
import { getCookie } from 'typescript-cookie';
import { onMounted, ref } from 'vue';
import { TokenValidity, TokenValidator } from './models/common/TokenValidator';
import { ApiService } from './api/ApiService';
import Icon from './components/reusable/Icon.vue';
import { Icons } from './models/icons/Icons';
import { InteractableElementLight } from './models/style/InteractableElementStyles';
import Loading from './components/other/Loading.vue';

const isLoading = ref(true);

onMounted(() => {
    const bearerToken = getCookie("BearerToken")

    if (!bearerToken) {
        isLoading.value = false
        return
    }

    const validator = new TokenValidator(bearerToken)
    validator.getState().then(tokenState => {
        if (tokenState.validity === TokenValidity.ValidUserExists) {
            ApiService.getUserByEmail(tokenState.user.email)
                .then(user => {
                    store.actions.setCurrentlyLoggedInUser(user.email, bearerToken)
                    isLoading.value = false
                })
        }
        else {
            isLoading.value = false
        }
    })
})



</script>

<template>
    <div class="app-container">
        <Loading v-if="isLoading" class="app-loading-screen" />
        <div class="app" v-else>
            <MainView v-if="store.state.userState.isLoggedIn" />
            <Authentication v-else />
        </div>
    </div>
</template>

<style scoped>
.app-container {
    width: 100vw;
    height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;
    font-family: 'Segoe UI', 'Arial Narrow', Arial, sans-serif;
}

.app-loading-screen {
    width: 20%;
    height: 20%;
}
</style>
