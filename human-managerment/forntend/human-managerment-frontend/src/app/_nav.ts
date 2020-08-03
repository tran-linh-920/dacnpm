import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    title: true,
    name: 'Quản lý nhân sự'
  },
  {
    name: 'Quản lý nhân viên',
    url: '/quan-ly-nhan-vien',
    icon: 'icon-user',
    children: [
      {
        name: 'Thông tin cơ bản',
        url: '/quan-ly-nhan-vien/thong-tin-co-ban'
      },
      {
        name: 'Giấy tờ tùy thân',
        url: '/quan-ly-nhan-vien/giay-to-tuy-than'
      },
      {
        name: 'Bằng cấp',
        url: '/quan-ly-nhan-vien/bang-cap'
      }
    ]
  },
  {
    name: 'Quản lý công việc',
    url: '/quan-ly-cong-viec',
    icon: 'icon-briefcase',
    children: [
      {
        name: 'Thông tin công việc',
        url: '/quan-ly-cong-viec/thong-tin-cong-viec'
      },
      {
        name: 'Phòng ban',
        url: '/quan-ly-cong-viec/phong-ban'
      },
      {
        name: 'Lich công tác',
        url: '/quan-ly-cong-viec/lich-cong-tac'
      }
    ]
  },
  {
    name: 'Quản lý thời gian',
    url: '/quan-ly-thoi-gian',
    icon: 'icon-clock',
    children: [
      {
        name: 'Thời gian làm việc',
        url: '/quan-ly-thoi-gian/thoi-gian-lam-viec'
      },
      {
        name: 'Ca làm việc',
        url: '/quan-ly-thoi-gian/ca-lam-viec'
      }
    ]
  },
  {
    name: 'Quản lý chấm công',
    icon: 'icon-check',
    children: [
      {
        name: 'Chấm công',
        url: '/quan-ly-cham-cong/cham-cong'
      },
    ],
  },
  {
    name: 'Quản lý vị trí',
    url: '/quan-ly-vị-tri',
    icon: 'icon-location-pin',
    children: [
      {
        name: 'Phường-Xã',
        url: '/quan-ly-vi-tri/phuong-xa'
      },
      {
        name: 'Quận-Huyện',
        url: '/quan-ly-vi-tri/quan-huyen'
      },
      {
        name: 'Tỉnh-Thành phố',
        url: '/quan-ly-vi-tri/tinh-thanh-pho'
      }
    ]
  },
  {
    title: true,
    name: 'Component'
  },
  {
    name: 'Base',
    url: '/base',
    icon: 'icon-puzzle',
    children: [
      {
        name: 'Cards',
        url: '/base/cards',
        icon: 'icon-puzzle'
      },
      {
        name: 'Carousels',
        url: '/base/carousels',
        icon: 'icon-puzzle'
      },
      {
        name: 'Collapses',
        url: '/base/collapses',
        icon: 'icon-puzzle'
      },
      {
        name: 'Forms',
        url: '/base/forms',
        icon: 'icon-puzzle'
      },
      {
        name: 'Navbars',
        url: '/base/navbars',
        icon: 'icon-puzzle'

      },
      {
        name: 'Pagination',
        url: '/base/paginations',
        icon: 'icon-puzzle'
      },
      {
        name: 'Popovers',
        url: '/base/popovers',
        icon: 'icon-puzzle'
      },
      {
        name: 'Progress',
        url: '/base/progress',
        icon: 'icon-puzzle'
      },
      {
        name: 'Switches',
        url: '/base/switches',
        icon: 'icon-puzzle'
      },
      {
        name: 'Tables',
        url: '/base/tables',
        icon: 'icon-puzzle'
      },
      {
        name: 'Tabs',
        url: '/base/tabs',
        icon: 'icon-puzzle'
      },
      {
        name: 'Tooltips',
        url: '/base/tooltips',
        icon: 'icon-puzzle'
      }
    ]
  },
  {
    name: 'Buttons',
    url: '/buttons',
    icon: 'icon-cursor',
    children: [
      {
        name: 'Buttons',
        url: '/buttons/buttons',
        icon: 'icon-cursor'
      },
      {
        name: 'Dropdowns',
        url: '/buttons/dropdowns',
        icon: 'icon-cursor'
      },
      {
        name: 'Brand Buttons',
        url: '/buttons/brand-buttons',
        icon: 'icon-cursor'
      }
    ]
  },
  {
    name: 'Charts',
    url: '/charts',
    icon: 'icon-pie-chart'
  },
  {
    name: 'Icons',
    url: '/icons',
    icon: 'icon-star',
    children: [
      {
        name: 'CoreUI Icons',
        url: '/icons/coreui-icons',
        icon: 'icon-star',
        badge: {
          variant: 'success',
          text: 'NEW'
        }
      },
      {
        name: 'Flags',
        url: '/icons/flags',
        icon: 'icon-star'
      },
      {
        name: 'Font Awesome',
        url: '/icons/font-awesome',
        icon: 'icon-star',
        badge: {
          variant: 'secondary',
          text: '4.7'
        }
      },
      {
        name: 'Simple Line Icons',
        url: '/icons/simple-line-icons',
        icon: 'icon-star'
      }
    ]
  },
  {
    name: 'Notifications',
    url: '/notifications',
    icon: 'icon-bell',
    children: [
      {
        name: 'Alerts',
        url: '/notifications/alerts',
        icon: 'icon-bell'
      },
      {
        name: 'Badges',
        url: '/notifications/badges',
        icon: 'icon-bell'
      },
      {
        name: 'Modals',
        url: '/notifications/modals',
        icon: 'icon-bell'
      }
    ]
  },
  {
    name: 'Widgets',
    url: '/widgets',
    icon: 'icon-calculator',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  {
    divider: true
  },
  {
    title: true,
    name: 'Extras',
  },
  {
    name: 'Pages',
    url: '/pages',
    icon: 'icon-star',
    children: [
      {
        name: 'Login',
        url: '/login',
        icon: 'icon-star'
      },
      {
        name: 'Register',
        url: '/register',
        icon: 'icon-star'
      },
      {
        name: 'Error 404',
        url: '/404',
        icon: 'icon-star'
      },
      {
        name: 'Error 500',
        url: '/500',
        icon: 'icon-star'
      }
    ]
  },
  {
    title: true,
    name: 'Theme'
  },
  {
    name: 'Colors',
    url: '/theme/colors',
    icon: 'icon-drop'
  },
  {
    name: 'Typography',
    url: '/theme/typography',
    icon: 'icon-pencil'
  },
  {
    name: 'Disabled',
    url: '/dashboard',
    icon: 'icon-ban',
    badge: {
      variant: 'secondary',
      text: 'NEW'
    },
    attributes: { disabled: true },
  },
  {
    name: 'Download CoreUI',
    url: 'http://coreui.io/angular/',
    icon: 'icon-cloud-download',
    class: 'mt-auto',
    variant: 'success',
    attributes: { target: '_blank', rel: 'noopener' }
  },
  {
    name: 'Try CoreUI PRO',
    url: 'http://coreui.io/pro/angular/',
    icon: 'icon-layers',
    variant: 'danger',
    attributes: { target: '_blank', rel: 'noopener' }
  }
];
