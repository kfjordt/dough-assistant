<template>
    <div class="navbar">
        <IconButton @click="handleLogoutClick" :elementStyle="InteractableElementLight" :icon="Icons.Gear" />
    </div>
</template>

<script setup lang="ts">
import IconButton from '../reusable/IconButton.vue';
import store from '../../store/store';
import { InteractableElementLight } from '../../models/style/InteractableElementStyles';
import { Icons } from '../../models/icons/Icons';

const handleLogoutClick = () => {
    store.actions.setUserToLoggedOut()
}

</script>

<style scoped>
.navbar {
    padding: 10px;
    height: 50px;
}
</style>