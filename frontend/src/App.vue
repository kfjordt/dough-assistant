<script setup lang="ts">
import MainView from './components/mainApp/MainView.vue';
import Authentication from './components/other/Authentication.vue';
import Tooltip from './components/other/Tooltip.vue';
import { getCookie } from 'typescript-cookie';
import { onMounted, ref } from 'vue';
import { TokenValidity, TokenValidator } from './models/common/TokenValidator';
import { ApiService } from './api/ApiService';;
import Loading from './components/other/Loading.vue';
import { getSectionStyles } from './models/style/SectionStyles';
import { useStore } from './store/store';

const store = useStore()
const isLoading = ref(true);

onMounted(() => {
    // const bearerToken = getCookie("BearerToken")

    // if (!bearerToken) {
        isLoading.value = false
    //     return
    // }

    // const validator = new TokenValidator(bearerToken)
    // validator.getState().then(tokenState => {
    //     if (tokenState.validity === TokenValidity.ValidUserExists) {
    //         ApiService.getUserByEmail(tokenState.user.email)
    //             .then(user => {
    //                 store.setCurrentlyLoggedInUser(user.email, bearerToken)
    //                 isLoading.value = false
    //             })
    //     }
    //     else {
    //         isLoading.value = false
    //     }
    // })
})
</script>

<template>
    <div class="app-container">
        <Loading v-if="isLoading" class="app-loading-screen" />
        <div v-else class="app">
            <MainView v-if="store.userState.isLoggedIn" />
            <Authentication v-else />
        </div>
        <Tooltip />
    </div>
</template>

<style scoped>
.app-container {
    font-family: 'Segoe UI', 'Arial Narrow', Arial, sans-serif;
}

.app {
    width: 100vw;
    height: 100vh;
    display: flex;
    align-items: center;
    justify-content: center;
}

.app-loading-screen {
    width: 20%;
    height: 20%;
}
</style>
