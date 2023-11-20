<script setup lang="ts">
import { useUserStore } from '../stores/user';
import { ref, onMounted } from 'vue';
import Calendar from './calendar/Calendar.vue';
import Authentication from './other/Authentication.vue';
import Tooltip from './other/Tooltip.vue';
import Loading from './other/Loading.vue';
import NavBar from './navBar/NavBar.vue';

const userStore = useUserStore()
const isLoading = ref(true);

onMounted(() => {
    // Here, implement the method described in
    // https://stackoverflow.com/questions/244882/what-is-the-best-way-to-implement-remember-me-for-a-website
    isLoading.value = false
})
</script>

<template>
    <div class="app-container">
        <Loading v-if="isLoading" class="app-loading-screen" />
        <div v-else class="app">
            <div class="main-view" v-if="userStore.loggedInUserId !== null">
                <NavBar />
                <Calendar />
            </div>
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

.main-view {
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    user-select: none;
}
</style>
