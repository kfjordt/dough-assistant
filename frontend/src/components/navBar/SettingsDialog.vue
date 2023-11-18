<template>
    <div :style="{
        backgroundColor: modalStyle.background,
        color: modalStyle.icon
    }" class="settings-dialog">
        <div class="darkmode-card-checkbox">
            <span>Dark mode enabled</span>
            <IconButton :style="modalStyle" @click="handleDarkModeToggle()" :icon="currentIcon" />
        </div>
    </div>
</template>

<script setup lang="ts">
import { useStyleStore } from '../../stores/style';
import { computed } from '@vue/reactivity';
import IconButton from '../reusable/IconButton.vue';
import { Icons } from '../../models/icons/Icons';

const styleStore = useStyleStore()

const modalStyle = computed(() => styleStore.sectionStyles.other.modals)
const currentIcon = computed(() => styleStore.currentMode === "dark" ? Icons.CheckedCheckbox : Icons.EmptyCheckbox)

const handleDarkModeToggle = () => {
    styleStore.toggleDarkMode()
}
</script>

<style scoped>
.settings-dialog {
    position: absolute;
    top: 42px;
    border-radius: 4px;
    right: 4px;
    text-align: start;
    z-index: 10;
}

.darkmode-card-checkbox {
    display: flex;
    align-items: center;
    font-size: small;
    padding: 8px;
}
</style>