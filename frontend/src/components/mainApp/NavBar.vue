<template>
    <!-- <div class="navbar">
        <CalendarNavigator />
        <IconButton @click="handleLogoutClick" :style="style.navBar.settingsButton" :icon="Icons.Gear" :tooltip="settingsTooltip" />
    </div> -->
</template>

<script setup lang="ts">
// import IconButton from '../reusable/IconButton.vue';
// import store from '../../store/store';
// import { Icons } from '../../models/icons/Icons';
// import { Tooltip } from '../../store/TooltipState';
// import { Anchor } from '../../models/geometry/Anchor';
// import CalendarNavigator from './CalendarNavigator.vue';
// import { computed } from '@vue/reactivity';

// const handleLogoutClick = () => {
//     // store.actions.setUserToLoggedOut()
// }

// const style = computed(() => {
//     return store.actions.getSectionStyles()
// })

// const settingsTooltip: Tooltip = {
//     content: "Open settings",
//     shortcut: "Ctrl+S",
//     anchor: Anchor.Southeast,
//     style: style.value.modals.tooltip
// }

</script>

<style scoped>
.navbar {
    padding: 10px;
    background-color: black;
    display: flex;
    color: white;
    justify-content: space-between;
}
</style>