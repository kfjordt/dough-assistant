<template>
    <div class="navbar-header">
        <IconButton @click="handleSettingsToggle" :style="navBarStyle.settingsButton" :icon="Icons.Gear" />
        <transition name="fade">
            <SettingsDialog v-if="showSettings" />
        </transition>
    </div>
</template>

<script setup lang="ts">
import { computed } from '@vue/reactivity';
import { useStyleStore } from '../../stores/style';
import { Icons } from '../../models/icons/Icons';
import IconButton from '../reusable/IconButton.vue';
import { ref } from 'vue';
import SettingsDialog from "./SettingsDialog.vue"

const navBarStyle = computed(() => useStyleStore().sectionStyles.navBar)
const showSettings = ref(false)

const handleSettingsToggle = () => {
    showSettings.value = !showSettings.value
}
</script>

<style scoped>
.navbar-header {
    display: flex;
    align-items: center;
}

.fade-enter-active,
.fade-leave-active {
    transition: opacity 0.2s ease;
}

.fade-enter-from,
.fade-leave-to {
    opacity: 0;
}
</style>