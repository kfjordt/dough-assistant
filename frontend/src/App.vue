<script setup lang="ts">
import MainView from './components/MainView.vue';
import NavBar from './components/NavBar.vue';

</script>

<template>
    <div class="app">
        <NavBar />
        <MainView />
    </div>
</template>

<style scoped>
.app {
    width: 100vw;
    height: 100vh;
    display: flex;
    flex-direction: column;
}

.app {
    --navbar-color-bg-primary: #1f2a2e;
    --navbar-color-bg-secondary: #243135;
    --navbar-color-text-primary: #cdcdcd;
    --navbar-color-text-secondary: #a2bfa2;
    --navbar-color-button-primary: #3c5057;
    --navbar-color-button-secondary: #4b656e;
    
    --mainview-color-bg-primary: #101517;
    --mainview-color-bg-secondary: #2a383d;
    --mainview-color-text-primary: #7fa77e;
    --mainview-color-text-secondary: #50744f;

    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
}
</style>
