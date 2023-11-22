<template>
    <div class="navbar-header">

        <Dropdown horizontalAlignment="right" @clickOutside="handleCurrencyToggle(false)" :showDropdown="showCurrencyDropdown">
            <IconButton @click="handleCurrencyToggle(true)" :style="navBarStyle.settingsButton" :icon="Icons.Currency" />
            <template v-slot:dropdown-content>
                <CurrencyPanel />
            </template>
        </Dropdown>

        <IconButton @click="handleSettingsToggle" :style="navBarStyle.settingsButton" :icon="Icons.Gear" />
    </div>
</template>

<script setup lang="ts">
import { computed } from '@vue/reactivity';
import { useStyleStore } from '../../stores/style';
import { Icons } from '../../models/icons/Icons';
import IconButton from '../reusable/IconButton.vue';
import Dropdown from '../reusable/Dropdown.vue';
import CurrencyPanel from "./CurrencyPanel.vue"
import { ref } from 'vue';

const navBarStyle = computed(() => useStyleStore().sectionStyles.navBar)

const showCurrencyDropdown = ref(false)
const handleCurrencyToggle = (show: boolean) => {
    showCurrencyDropdown.value = show
}


const handleSettingsToggle = () => {
}
</script>

<style scoped>
.navbar-header {
    display: flex;
    align-items: center;
    padding: 4px;
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